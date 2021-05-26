namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class CreateCustomer: ExtendedCustomer
    {
        public Address Address { get; set; }
        public EmailAddress Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
    }
}
