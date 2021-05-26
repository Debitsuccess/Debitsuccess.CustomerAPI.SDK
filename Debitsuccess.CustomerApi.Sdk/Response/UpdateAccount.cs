using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class UpdateAccount: BaseResponse
    {
        public string AccountId { get; set; }
        public string AccountCode { get; set; }
        public string AccountExternalId { get; set; }
        public string TermType { get; set; }
        public int Term { get; set; }
        public bool FixedTerm { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime AccountStartDate { get; set; }
        public bool PaymentStopped { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter), "yyyy-MM-dd")]
        public DateTime? PaymentStoppedEndDate { get; set; }
        public decimal? ContractAmount { get; set; }
    }
}
