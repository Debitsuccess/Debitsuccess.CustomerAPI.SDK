using Debitsuccess.CustomerApi.Sdk.Response;
using System;
using System.Runtime.Serialization;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Request
{

    public class CreateCustomer: BaseRequest
    {
        public int? CustomerId { get; set; }
        public int BusinessId { get; set; }
        public string CustomerType { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ExternalReference { get; set; }
        [JsonFormatter(typeof(DateTimeFormatter), "yyyy-MM-dd")]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public EmailAddress EmailAddress { get; set; }
        [DataMember]
        public PhoneNumber PhoneNumber { get; set; }
    }
}
