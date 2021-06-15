using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class RecurringSchedule: BaseResponse
    {
        public int ScheduleId { get; set; }
        public string AccountId { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime MinimumEffectiveDate {  get; set; }
        public DateTime RecurringScheduleStartDate { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? RecurringScheduleEndDate { get; set; }
        public decimal Installment { get; set; }
        public string Frequency { get; set; }
        public string ScheduleDescription { get; set; }
        public string ExternalScheduleId { get; set; }
        public bool? DeleteFutureSchedules { get; set; }
        public bool? OverrideBillingCycleAlignment { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter), "yyyy-MM-dd")]
        public DateTime? PreviousScheduleEndDate { get; set; }
    }
}
