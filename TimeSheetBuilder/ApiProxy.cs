using System;
using System.Collections.Generic;
using ConnectWiseDotNetSDK.ConnectWise.Client;
using ConnectWiseDotNetSDK.ConnectWise.Client.Common.Model;
using ConnectWiseDotNetSDK.ConnectWise.Client.Schedule.Api;
using ConnectWiseDotNetSDK.ConnectWise.Client.Schedule.Model;
using ConnectWiseDotNetSDK.ConnectWise.Client.System.Api;
using ConnectWiseDotNetSDK.ConnectWise.Client.System.Model;
using ConnectWiseDotNetSDK.ConnectWise.Client.Time.Api;
using ConnectWiseDotNetSDK.ConnectWise.Client.Time.Model;

namespace TimeSheetBuilder
{
    public class ApiProxy
    {
        private ApiClient apiClient;

        public ApiProxy()
        {
            apiClient = new ApiClient(Properties.Settings.Default["apicookie"].ToString());
            apiClient.SetCompanyName(Properties.Settings.Default["apicompanyname"].ToString());
            apiClient.SetSite(Properties.Settings.Default["apisite"].ToString());
            apiClient.SetPublicPrivateKey(Properties.Settings.Default["hVUKBayRaFJRSjL"].ToString(), Properties.Settings.Default["XmgJQbghcPMmtta"].ToString());
        }

        public int GetChargeCodeRecIDFromChargeCode(string chargeCodeName)
        {
            var api = new ChargeCodesApi(apiClient);
            var response = api.GetChargeCodes("Name = '" + chargeCodeName + "'", null, null, null);
            if (!response.IsSuccessResponse())
                throw new ApplicationException(response.GetError().Message);

            var chargeCode = new ChargeCode() { Id = -1 };
            var result = response.GetResult<List<ChargeCode>>();
            if (result.Count > 0)
                chargeCode = result[0];

            return chargeCode.Id.Value;
        }

        public List<TimeEntry> GetTimeEntryList(DateTime startDate, DateTime endDate, string memberID)
        {
            var api = new TimeEntriesApi(apiClient);
            var conditions = "Member/Identifier = '" + memberID + "' AND TimeStart >= [" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "] AND TimeStart <= [" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "]";

            var response = api.GetEntries(conditions, "TimeStart, TimeEnd desc", null, null, null, 200);
            if (!response.IsSuccessResponse())
                throw new ApplicationException(response.GetError().Message);

            return response.GetResult<List<TimeEntry>>();
        }

        public List<ScheduleEntry> GetScheduleEntryList(DateTime startDate, DateTime endDate, string memberID)
        {
            var api = new ScheduleEntriesApi(apiClient);
            var conditions = "Member/Identifier = '" + memberID + "' AND DateStart >= [" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "Z] AND DateStart <= [" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "Z] AND DoneFlag = false";

            var response = api.GetEntries(conditions, "DateStart, DateEnd desc", null, null, null, 200);
            if (!response.IsSuccessResponse())
                throw new ApplicationException(response.GetError().Message);

            return response.GetResult<List<ScheduleEntry>>();
        }

        public TimeEntry CreateNewTimeEntry(TimeEntry timeEntry)
        {
            var api = new TimeEntriesApi(apiClient);
            var response = api.CreateEntry(timeEntry);
            if (!response.IsSuccessResponse())
                throw new ApplicationException(response.GetError().Message);

            return response.GetResult<TimeEntry>();
        }

        //public void MarkScheduleAsDone(ScheduleEntry schedule)
        //{
        //    var api = new ScheduleEntriesApi(apiClient);
        //    if (schedule.DoneFlag.HasValue && schedule.DoneFlag.Value)
        //        return;

        //    schedule.DoneFlag = true;
        //    schedule.AllowScheduleConflictsFlag = true;
        //    var response = api.ReplaceEntryById(schedule.Id, schedule);
        //    if (!response.IsSuccessResponse())
        //        throw new ApplicationException(response.GetError().Message);
        //}

        public void MarkScheduleAsDone(ScheduleEntry schedule)
        {
            var api = new ScheduleEntriesApi(apiClient);
            if (schedule.DoneFlag.HasValue && schedule.DoneFlag.Value)
                return;

            var patchOps = new List<PatchOperation>
            {
                new PatchOperation
                {
                    Op = "replace",
                    Path = "allowScheduleConflictsFlag",
                    Value = "true"
                },
                new PatchOperation
                {
                    Op = "replace",
                    Path = "doneFlag",
                    Value = "true"
                }
            };

            var response = api.UpdateEntryById(schedule.Id, patchOps);
            if (!response.IsSuccessResponse())
                throw new ApplicationException(response.GetError().Message);
        }
    }
}
