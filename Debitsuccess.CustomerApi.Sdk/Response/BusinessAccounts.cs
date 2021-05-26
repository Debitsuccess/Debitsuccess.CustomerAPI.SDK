using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class BusinessAccounts : BaseResponse, IGetAll<BusinessAccount>
    {
        [DataMember(Name = "businessAccounts")]
        public List<BusinessAccount> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
