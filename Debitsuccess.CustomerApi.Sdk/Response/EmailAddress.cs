using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class EmailAddress: BaseResponse
    {
        public int EmailAddressId { get; set; }
        public string EmailName { get; set; }
        [DataMember(Name = "emailAddress")]
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
    }
}
