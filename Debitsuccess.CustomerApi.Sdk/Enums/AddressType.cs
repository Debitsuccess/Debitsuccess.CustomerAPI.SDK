namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    /// <summary>
    /// Represents possible types of addresses in Debitsuccess Customer API
    /// business, home, physical, postal, legal
    /// <seealso cref="https://debitsuccess.stoplight.io/docs/debitsuccess-api/CustomerServicesApi.yaml/paths/~1customers~1%7BcustomerId%7D~1addresses/post"/>
    /// </summary>
    public class AddressType: Enumeration
    {
        
        public static readonly AddressType Business = new AddressType(nameof(Business), "business");
        public static readonly AddressType Home = new AddressType(nameof(Home), "home");
        public static readonly AddressType Physical = new AddressType(nameof(Physical), "physical");
        public static readonly AddressType Postal = new AddressType(nameof(Postal), "postal");
        public static readonly AddressType Legal = new AddressType(nameof(Legal), "legal");
        private AddressType(string displayName, string value) : base(displayName, value) { }
    }
}
