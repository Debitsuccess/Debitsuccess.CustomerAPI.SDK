using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using Utf8Json;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Account: BaseResponse
    {
        public string AccountId { get; set; }
        public string AccountExternalId { get; set; }
        public int CustomerId { get; set; }
        public string BusinessAccountId { get; set; }
        public string TermType { get; set; }
        public int Term { get; set; }
        public string AccountCode { get; set; }
        public string AccountNotes { get; set; }
        public bool FixedTerm { get; set; }
        public DateTime NextBillingDate { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? LastBillingDateTime { get; set; }
        public int OverdueStatus { get; set; }
        public decimal OverdueAmountPayment { get; set; }
        public decimal OverdueAmountFee { get; set; }
        public string LastReversalReason { get; set; }
        public string CloseReason { get; set; }
        public bool Suspended { get; set; }
        public bool PaymentStopped { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? PaymentStopEndDate { get; set; }
        public decimal CatchUpAmount { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? CatchUpEndDate { get; set; }
        public decimal PaymentInAdvanceAmount { get; set; }
        public string PaymentInAdvanceEndDate { get; set; }
        public DateTime AccountStartDate { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? AccountCloseDateTime { get; set; }
        public DateTime AccountLoadedDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public decimal AccruedContractAmount { get; set; }
        public decimal OriginalContractAmount { get; set; }
        public decimal OutstandingRecurringAmount { get; set; }
        public decimal OutstandingOneOffAmount { get; set; }
        public decimal OutstandingFeeAmount { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? ProjectedFinishDate { get; set; }
        public string PaymentMethodToken { get; set; }
        public string CollectionStopReason { get; set; }
    }
}
