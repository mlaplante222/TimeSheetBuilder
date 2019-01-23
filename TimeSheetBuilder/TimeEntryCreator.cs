using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ConnectWiseDotNetSDK.ConnectWise.Client.Common.Model;
using ConnectWiseDotNetSDK.ConnectWise.Client.Schedule.Model;
using ConnectWiseDotNetSDK.ConnectWise.Client.Time.Model;

namespace TimeSheetBuilder
{
    public class TimeEntryCreator
    {
        private ApiProxy api;

        public TimeEntryCreator(ApiProxy api)
        {
            this.api = api;
        }

        public List<TimeEntry> CreateTimeEntriesForSchedules(List<TimeEntry> timeEntries, List<ScheduleEntry> scheduleEntries, string memberID, ChargeTo chargeTo)
        {
            foreach (var schedule in scheduleEntries)
            {
                var timeEntryExists = timeEntries.Where(t => t.TimeStart.Value.Date == schedule.DateStart.Value.Date && t.TimeStart.Value.TimeOfDay < schedule.DateEnd.Value.TimeOfDay && t.TimeEnd.Value.TimeOfDay > schedule.DateStart.Value.TimeOfDay).Any();
                if (timeEntryExists)
                    continue;

                try
                {
                    var timeEntry = addNewTimeEntryFromSchedule(schedule, memberID, chargeTo);
                    if (timeEntry != null)
                        timeEntries.Add(timeEntry);
                }
                catch { }
            }

            return timeEntries;
        }

        public void CreateAdminTimeToFillGaps(DateTime startDate, DateTime endDate, string maxStart, string minEnd, string lunchDeduction, List<TimeEntry> timeEntries, string memberID, ChargeTo chargeTo)
        {
            var currentDate = startDate.ToLocalTime();
            var localEndDate = endDate.ToLocalTime();
            var start = maxStart.Split(':');
            var end = minEnd.Split(':');
            var lunch = lunchDeduction.Split(':');
            double lunchDeduct = Math.Round(ConversionUtils.GetInt(lunch[0]) + ConversionUtils.GetInt(lunch[1]) / 60.00, 2);
            var startHour = ConversionUtils.GetInt(start[0]);
            var startMin = start.Length > 1 ? ConversionUtils.GetInt(start[1]) : 0;
            var endHour = ConversionUtils.GetInt(end[0]);
            if (endHour < 12)
                endHour += 12;
            var endMin = end.Length > 1 ? ConversionUtils.GetInt(end[1]) : 0;
            while (currentDate <= localEndDate)
            {
                var startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, startHour, startMin, 0).ToUniversalTime();
                var endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, endHour, endMin, 0).ToUniversalTime();
                double totalHours = lunchDeduct;
                var todayTime = timeEntries.Where(t => t.TimeStart.Value.ToLocalTime().Date == currentDate.Date).ToList();
                foreach (var timeEntry in todayTime)
                {
                    if (timeEntry.TimeStart.Value < startTime)
                        startTime = timeEntry.TimeStart.Value;
                    if (timeEntry.TimeEnd.Value > endTime)
                        endTime = timeEntry.TimeEnd.Value;

                    totalHours += timeEntry.ActualHours.Value;
                }

                var maxHours = ConversionUtils.GetDouble(endTime.Subtract(startTime).TotalHours, 2);
                if (totalHours < maxHours)
                    addNewTimeEntry(startTime, endTime, totalHours, memberID, chargeTo);

                currentDate = currentDate.AddDays(1);
            }
        }

        private void addNewTimeEntry(DateTime startTime, DateTime endTime, double hoursDeduct, string memberID, ChargeTo chargeTo)
        {
            var timeEntry = new TimeEntry
            {
                Member = new MemberReference()
                {
                    Identifier = memberID
                },
                
                TimeStart = startTime,
                TimeEnd = endTime,
                HoursDeduct = hoursDeduct,
                EnteredBy = memberID,
                ChargeToType = chargeTo.TicketNumber == 0 ? TimeEntry.ChargeToTypeEnum.ChargeCode : TimeEntry.ChargeToTypeEnum.ServiceTicket,
                ChargeToId = chargeTo.TicketNumber == 0 ? chargeTo.ChargeCodeId : chargeTo.TicketNumber,
                AddToDetailDescriptionFlag = false,
                AddToInternalAnalysisFlag = false,
                AddToResolutionFlag = false
            };

            api.CreateNewTimeEntry(timeEntry);
        }

        private TimeEntry addNewTimeEntryFromSchedule(ScheduleEntry schedule, string memberID, ChargeTo chargeTo)
        {
            var startDate = schedule.DateStart.Value;
            var endDate = schedule.DateEnd.Value;
            if (startDate == endDate)
                return null;

            var chargeToType = schedule.Type.Id == 1 ? TimeEntry.ChargeToTypeEnum.Activity 
                                : schedule.Type.Id == 4 ? TimeEntry.ChargeToTypeEnum.ServiceTicket 
                                : schedule.Type.Id == 3 ? TimeEntry.ChargeToTypeEnum.ProjectTicket
                                : TimeEntry.ChargeToTypeEnum.ChargeCode;
            var timeEntry = new TimeEntry
            {
                Member = new MemberReference()
                {
                    Identifier = memberID
                },
                ChargeToType = chargeToType,

                ChargeToId = chargeToType == TimeEntry.ChargeToTypeEnum.ChargeCode ? chargeTo.ChargeCodeId : schedule.ObjectId.Value,
                HoursDeduct = 0,
                TimeStart = startDate,
                TimeEnd = endDate,
                EnteredBy = memberID,
                AddToDetailDescriptionFlag = false,
                AddToInternalAnalysisFlag = false,
                AddToResolutionFlag = false
            };

            return api.CreateNewTimeEntry(timeEntry);
        }
    }

    public class ChargeTo
    {
        private int ticketNumber;
        private int chargeCodeId;
        private string chargeCode;

        public int TicketNumber { get => ticketNumber; set => ticketNumber = value; }
        public int ChargeCodeId { get => chargeCodeId; set => chargeCodeId = value; }
        public string ChargeCode { get => chargeCode; set => chargeCode = value; }
    }
}
