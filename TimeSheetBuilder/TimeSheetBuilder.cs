using System;
using System.Collections.Generic;
using System.Linq;
using ConnectWiseDotNetSDK.ConnectWise.Client.Schedule.Model;

namespace TimeSheetBuilder
{
    public class TimeSheetBuilder
    {
        private ApiProxy api;
        public event ShowMessageHandler ShowMessage;

        public void BuildTimeSheet(DateTime startDate, DateTime endDate, string memberID, string maxStart, string minEnd, string lunchDeduction, string adminChargeCode, bool markSchedulesDone)
        {
            api = new ApiProxy();
            var chargeTo = new ChargeTo();
            
            if (adminChargeCode.All(char.IsNumber) && int.TryParse(adminChargeCode, out int t))
            {
                chargeTo.TicketNumber = t;
            }
            else
            {
                chargeTo.ChargeCode = adminChargeCode;
                chargeTo.ChargeCodeId = getAndCacheChargeCodeId(adminChargeCode);
            } 

            raiseProgressEvent("Getting existing time entries...");
            var timeList = api.GetTimeEntryList(startDate, endDate, memberID);

            raiseProgressEvent("Getting existing schedule entries...");
            var scheduleList = api.GetScheduleEntryList(startDate, endDate, memberID);

            var tec = new TimeEntryCreator(api);
            raiseProgressEvent("Creating time entries...");
            timeList = tec.CreateTimeEntriesForSchedules(timeList, scheduleList, memberID, chargeTo);

            raiseProgressEvent("Creating admin time...");
            tec.CreateAdminTimeToFillGaps(startDate, endDate, maxStart, minEnd, lunchDeduction, timeList, memberID, chargeTo);

            if (markSchedulesDone)
            {
                raiseProgressEvent("Marking schedules as Done...");
                markSchedulesAsDone(scheduleList);
            }

            raiseProgressEvent("Time sheet has been updated.");
        }

        private int getAndCacheChargeCodeId(string adminChargeCode)
        {
            var adminChargeCodeId = ConversionUtils.GetInt(ConfigSettings.GetValue("adminchargecodeid"));
            if (adminChargeCodeId == 0 && !string.IsNullOrEmpty(adminChargeCode))
            {
                raiseProgressEvent("Getting chargecode recid...");
                adminChargeCodeId = api.GetChargeCodeRecIDFromChargeCode(adminChargeCode);
                if (adminChargeCodeId <= 0)
                    throw new ApplicationException("Invalid charge code entered.");

                ConfigSettings.SetValue("adminchargecodeid", adminChargeCodeId.ToString());
                ConfigSettings.Save();
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
            ShowMessage?.Invoke(this, new ShowMessageEventArgs(message, false));
        }
    }

    public class ShowMessageEventArgs : EventArgs
    {
        public string Message;
        public bool IsError;
        public ShowMessageEventArgs(string message, bool isError)
        {
            Message = message;
            IsError = isError;
        }
    }
    public delegate void ShowMessageHandler(object sender, ShowMessageEventArgs e);
}
