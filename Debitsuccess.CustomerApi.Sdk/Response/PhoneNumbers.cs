using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PhoneNumbers: BaseResponse, IGetAll<PhoneNumber>
    {
        [DataMember(Name = "phoneNumbers")]
        public List<PhoneNumber> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
