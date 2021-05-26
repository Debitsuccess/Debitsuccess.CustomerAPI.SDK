using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class CreateAccountRecurringSchedule
    {
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime RecurringScheduleStartDate { get; set; }
        public decimal Installment { get; set; }
        public string Frequency { get; set; }
        public int? NumberOfPayments { get; set; }
        public string ExternalScheduleId { get; set; }
        public string ScheduleDescription { get; set; }
    }
}
