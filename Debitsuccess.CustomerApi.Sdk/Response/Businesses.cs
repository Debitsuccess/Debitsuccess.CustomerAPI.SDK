using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Businesses : BaseResponse, IGetAll<Business>
    {
        [DataMember(Name = "businesses")]
        public List<Business> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
