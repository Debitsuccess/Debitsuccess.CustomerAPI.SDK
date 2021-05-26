using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Customers : BaseResponse, IGetAll<Customer>
    {
        [DataMember(Name = "customers")]
        public List<Customer> Elements { get; set; }        
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
