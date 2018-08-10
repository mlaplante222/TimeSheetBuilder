using System;
using System.Linq;
using System.Collections.Generic;
using ConnectWiseDotNetSDK.ConnectWise.Client.Schedule.Model;

namespace TimeSheetBuilder
{
    public class TimeSheetBuilder
    {
        private ApiProxy api;
        public event ShowMessageHandler ShowMessage;

        public void BuildTimeSheet(DateTime startDate, DateTime endDate, string memberID, string maxStart, string minEnd, string lunchDeduction, string adminChargeCode)
        {
            api = new ApiProxy();
           
            var adminChargeCodeId = getAndCacheChargeCodeId(adminChargeCode);

            raiseProgressEvent("Getting existing time entries...");
            var timeList = api.GetTimeEntryList(startDate, endDate, memberID);

            raiseProgressEvent("Getting existing schedule entries...");
            var scheduleList = api.GetScheduleEntryList(startDate, endDate, memberID);

            var tec = new TimeEntryCreator(api);
            raiseProgressEvent("Creating time entries...");
            timeList = tec.CreateTimeEntriesForSchedules(timeList, scheduleList, memberID, adminChargeCodeId);

            raiseProgressEvent("Creating admin time...");
            tec.CreateAdminTimeToFillGaps(startDate, endDate, maxStart, minEnd, lunchDeduction, timeList, memberID, adminChargeCodeId);

            raiseProgressEvent("Marking schedules as Done...");
            markSchedulesAsDone(scheduleList);

            raiseProgressEvent("Time sheet has been updated.");
        }

        private int getAndCacheChargeCodeId(string adminChargeCode)
        {
            var adminChargeCodeId = ConversionUtils.GetInt(Properties.Settings.Default["adminchargecodeid"]);
            if (adminChargeCodeId == 0)
            {
                raiseProgressEvent("Getting chargecode recid...");
                adminChargeCodeId = api.GetChargeCodeRecIDFromChargeCode(adminChargeCode);
                if (adminChargeCodeId <= 0)
                    throw new ApplicationException("Invalid charge code entered.");

                Properties.Settings.Default["adminchargecodeid"] = adminChargeCodeId.ToString();
            }

            return adminChargeCodeId;
        }

        private void markSchedulesAsDone(List<ScheduleEntry> scheduleEntries)
        {
            foreach (var schedule in scheduleEntries.Where(s => !s.DoneFlag.HasValue || !s.DoneFlag.Value))
                api.MarkScheduleAsDone(schedule);
        }

        private void raiseProgressEvent(string message)
        {
            var eh = ShowMessage;
            if (eh != null)
                eh(message, false);
        }
    }

    public delegate void ShowMessageHandler(string message, bool isError);
}
