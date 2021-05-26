using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Accounts: BaseResponse, IGetAll<Account>
    {
        [DataMember(Name = "accounts")]
        public List<Account> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
