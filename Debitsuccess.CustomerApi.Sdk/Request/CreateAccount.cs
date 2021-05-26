using Debitsuccess.CustomerApi.Sdk.Response;
using System;
using System.Collections.Generic;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Request
{
    public class CreateAccount: BaseRequest
    {
        public int CustomerId { get; set; }
        public string BusinessAccountId { get; set; }
        public string AccountExternalId { get; set; }
        public string AccountCode { get; set; }
        public string TermType { get; set; }
        public int Term { get; set; }
        public string AccountNotes { get; set; }
        public bool FixedTerm { get; set; }
        public bool WaiveEstFee { get; set; }
        public bool AlignEstFeeWithSchedule { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime AccountStartDate { get; set; }
        public decimal? ContractAmount { get; set; }
        public string PaymentMethodToken { get; set; }
        public List<CreateAccountRecurringSchedule> RecurringSchedules { get; set; }
    }
}
