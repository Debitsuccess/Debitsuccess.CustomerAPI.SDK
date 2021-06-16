using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class SuspensionSchedule : BaseResponse
    {
        public int ScheduleId { get; set; }
        public string AccountId { get; set; }
        public string AccountExternalId { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime MinimumEffectiveDate { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime SuspensionScheduleStartDate { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter), "yyyy-MM-dd")]
        public DateTime? SuspensionScheduleEndDate { get; set; }
        public decimal SuspensionFee { get; set; }
        public int? NumberOfPayments { get; set; }
        public string Frequency { get; set; }
        public string ScheduleDescription { get; set; }
        public string ExternalScheduleId { get; set; }
    }
}
