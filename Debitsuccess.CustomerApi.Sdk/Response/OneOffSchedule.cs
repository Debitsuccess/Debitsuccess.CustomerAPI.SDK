using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class OneOffSchedule : BaseResponse
    {
        public int ScheduleId { get; set; }
        public string AccountId { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string ScheduleDescription { get; set; }
        public string ExternalScheduleId { get; set; }
    }
}
