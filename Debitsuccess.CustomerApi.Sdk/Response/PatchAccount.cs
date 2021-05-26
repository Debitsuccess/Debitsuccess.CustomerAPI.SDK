namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PatchAccount : BaseResponse
    {
        public string AccountId { get; set; }
        public string PaymentMethodToken { get; set; }
    }
}
