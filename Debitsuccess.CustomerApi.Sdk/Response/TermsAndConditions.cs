namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class TermsAndConditions: BaseResponse
    {
        public string BusinessAccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TermsHTML { get; set; }
    }
}
