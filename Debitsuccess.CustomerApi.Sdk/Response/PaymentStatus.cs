using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using System.Runtime.Serialization;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PaymentStatus : BaseResponse
    {
        public string BusinessAccountId { get; set; }
        public string AccountId { get; set; }
        public string Description { get; set; }
        public string ExternalIdentifier { get; set; }
        public decimal Installment { get; set; }
        [DataMember(Name = "paymentStatus")]
        public string Status { get; set; }
        public int ScheduleId { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime StartDate { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime StatusDateTime { get; set; }
        public string ErrorCode { get; set; }
    }
}
