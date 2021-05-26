namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Address: BaseResponse
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CountryISOCode { get; set; }
        public string AddressType { get; set; }
        public bool IsPrimary { get; set; }
    }
}
