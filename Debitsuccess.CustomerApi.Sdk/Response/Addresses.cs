using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Addresses : BaseResponse, IGetAll<Address>
    {
        [DataMember(Name = "addresses")]
        public List<Address> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
