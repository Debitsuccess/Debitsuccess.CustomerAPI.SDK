namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    /// <summary>
    /// Represents possible types of phone numbers in Debitsuccess Customer API
    /// emergency, fax, home, mobile, work
    /// <seealso cref="https://debitsuccess.stoplight.io/docs/debitsuccess-api/CustomerServicesApi.yaml/paths/~1customers~1%7BcustomerId%7D~1phoneNumbers/post"/>
    /// </summary>
    public class PhoneType: Enumeration
    {
        public static readonly PhoneType Emergency = new PhoneType(nameof(Emergency), "emergency");
        public static readonly PhoneType Home = new PhoneType(nameof(Home), "home");
        public static readonly PhoneType Fax = new PhoneType(nameof(Fax), "fax");
        public static readonly PhoneType Mobile = new PhoneType(nameof(Mobile), "mobile");
        public static readonly PhoneType Work = new PhoneType(nameof(Work), "work");
        private PhoneType(string displayName, string value) : base(displayName, value) { }
    }
}
