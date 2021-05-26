using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Payment : BaseResponse
    {
        public string BusinessAccountId { get; set; }
        public string AccountId { get; set; }
        public long BatchNumber { get; set; }
        public decimal PaymentAmount { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime PaymentDateTime { get; set; }
        public string PaymentDescription { get; set; }
        public string PaymentCode { get; set; }
        public string PaymentErrorCode { get; set; }
        public string PaymentMethod { get; set; }
        public long PaymentId { get; set; }
        public string ExternalPaymentIdentifier { get; set; }
        public long? ReversedPaymentId { get; set; }
        public int RetryCount { get; set; }
    }
}
