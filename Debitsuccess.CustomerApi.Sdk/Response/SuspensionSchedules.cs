using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class SuspensionSchedules : BaseResponse, IGetAll<SuspensionSchedule>
    {
        [DataMember(Name = "suspensionSchedules")]
        public List<SuspensionSchedule> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
