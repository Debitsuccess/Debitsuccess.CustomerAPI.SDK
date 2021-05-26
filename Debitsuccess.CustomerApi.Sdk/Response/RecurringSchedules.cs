using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class RecurringSchedules : BaseResponse, IGetAll<RecurringSchedule>
    {
        [DataMember(Name = "recurringSchedules")]
        public List<RecurringSchedule> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
