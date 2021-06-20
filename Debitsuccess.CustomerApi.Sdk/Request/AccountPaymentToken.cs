namespace Debitsuccess.CustomerApi.Sdk.Request
{
    public class AccountPaymentToken : BaseRequest
    {
        public decimal Amount { get; set; }
        public string CallbackURL { get; set; }
        public bool CreateOneOffCharge { get; set; }
        public string PaymentNote { get; set; }
    }
}
