namespace Debitsuccess.CustomerApi.Sdk.Request
{
    public class CasualPaymentToken : BaseRequest
    {
        public decimal Amount { get; set; }
        public string CallbackURL { get; set; }
        public string PaymentNote { get; set; }
        public string PaymentRef { get; set; }
    }
}
