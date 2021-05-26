using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class BaseResponse
    {
        [IgnoreDataMember]
        public int StatusCode { get; set; }
    }
}
