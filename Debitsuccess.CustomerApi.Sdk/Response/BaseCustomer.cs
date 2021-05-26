using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using Utf8Json;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class BaseCustomer: BaseResponse
    {
        public int CustomerId { get; set; }
        public string CustomerType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ExternalReference { get; set; }
        [JsonFormatter(typeof(EmptyOrNullableDateTimeFormatter), "yyyy-MM-dd")]
        public DateTime? DateOfBirth { get; set; }
    }
}
