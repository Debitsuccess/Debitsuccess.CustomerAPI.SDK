using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using System.Collections.Generic;
using Utf8Json;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class CreateAccount: BaseResponse
    {
        public string AccountId { get; set; }
        public string BusinessAccountId { get; set; }
        public int CustomerId { get; set; }
        public string AccountExternalId { get; set; }
        public string AccountCode { get; set; }
        public string TermType { get; set; }
        public int Term{ get; set; }
        public string AccountNotes { get; set; }
        public bool FixedTerm { get; set; }
        public DateTime NextBillingDate { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? LastBillingDateTime { get; set; }
        public int OverdueStatus { get; set; }
        public decimal OverdueAmountPayment { get; set; }
        public decimal overdueAmountFee { get; set; }
        public string LastReversalReason { get; set; }
        public string CloseReason { get; set; }
        public bool Suspended { get; set; }
        public bool PaymentStopped { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? PaymentStopEndDate { get; set; }
        public decimal CatchUpAmount { get; set; }
        public string CatchUpEndDate { get; set; }
        public decimal PaymentInAdvanceAmount { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? PaymentInAdvanceEnddate { get; set; }
        public bool waiveEstFee { get; set; }
        public string accountStartDate { get; set; }
        public DateTime accountLoadedDateTime { get; set; }
        public string AccountCloseDateTime { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }
        public decimal AccruedContractAmount { get; set; }
        public decimal OriginalContractAmount { get; set; }
        public decimal OutstandingRecurringAmount { get; set; }
        public decimal OutandingOneOffAmount { get; set; }
        public decimal OutstandingFeeAmount { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter))]
        public DateTime? ProjectedFinishDate { get; set; }
        public string PaymentMethodToken { get; set; }
        public List<CreateAccountRecurringSchedule> RecurringSchedules { get; set; }
    }
}
