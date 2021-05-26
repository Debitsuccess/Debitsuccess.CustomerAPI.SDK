using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class OneOffSchedules : BaseResponse, IGetAll<OneOffSchedule>
    {
        [DataMember(Name = "oneOffSchedules")]
        public List<OneOffSchedule> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
