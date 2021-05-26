using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PhoneNumber: BaseResponse
    {
        public int PhoneNumberId { get; set; }
        public string PhoneName { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
        [DataMember(Name = "phoneNumber")]
        public string Number { get; set; }
        public string PhoneType { get; set; }
        public bool IsPrimary { get; set; }
    }
}
