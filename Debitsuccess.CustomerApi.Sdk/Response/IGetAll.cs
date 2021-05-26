using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public interface IGetAll<T>
    {
        [IgnoreDataMember]
        public int StatusCode { get; set; }
        List<T> Elements { get; set; }
        ResponseMetadata ResponseMetadata { get; set; }
    }
}
