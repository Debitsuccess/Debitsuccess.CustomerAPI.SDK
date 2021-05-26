using System;
using System.Collections.Generic;
using System.Text;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Request
{
    public class UpdateSuspensionSchedule : BaseRequest
    {
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime SuspensionScheduleEndDate { get; set; }
    }
}
