using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PaymentToken : BaseResponse
    {
        public string Token { get; set; }
        public string WebhookToken { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-ddTHH:mm:ss.fffZ")]
        public DateTime ValidTo { get; set; }
        public string PaymentFormURL { get; set; }
    }
}
