using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Utf8Json;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class OverdueStatusChanges : BaseResponse, IGetAll<OverdueStatusChange>
    {
        [DataMember(Name = "overdueStatusChanges")]
        public List<OverdueStatusChange> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }

    public class OverdueStatusChange : BaseResponse
    {
        public string BusinessAccountId { get; set; }
        public string AccountId { get; set; }
        public string AccountExternalId { get; set; }
        public int? FromOverdueStatus { get; set; }
        public decimal? FromOverdueAmount { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? FromODtatusChangeDateTime { get; set; }
        public int ToOverdueStatus { get; set; }
        public decimal ToOverdueAmount { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime? ToODtatusChangeDateTime { get; set; }
    }
}
