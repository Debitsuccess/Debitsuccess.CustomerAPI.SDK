using System;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Request
{
    public class UpdateCustomer : BaseRequest
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime DateOfBirth { get; set; }
    }
}
