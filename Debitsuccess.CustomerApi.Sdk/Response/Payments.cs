using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Payments : BaseResponse, IGetAll<Payment>
    {
        [DataMember(Name = "payments")]
        public List<Payment> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
