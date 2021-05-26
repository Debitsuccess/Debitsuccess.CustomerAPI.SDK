namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PaymentMethod : BaseResponse
    {
        public string PaymentMethodToken { get; set; }
        public string PaymentMethodType { get; set; }
        public string HolderName { get; set; }
        public string Number { get; set; }
        public string CardType { get; set; }
        public string CardExpiryDate { get; set; }
        public bool? DefaultPaymentMethod { get; set; }
    }
}
