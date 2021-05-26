using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class EmailAddresses : BaseResponse, IGetAll<EmailAddress>
    {
        [DataMember(Name = "emailAddresses")]
        public List<EmailAddress> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
