namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    /// <summary>
    /// Enumeration represents ISO codes of countries where Debitsuccess operates
    /// <seealso cref="https://debitsuccess.stoplight.io/docs/debitsuccess-api/docs/Introduction/6-Reference.md#countryisocode"/>
    /// </summary>
    public class CountryType : Enumeration
    {
        public static readonly CountryType Australia = new CountryType(nameof(Australia), "AUS");
        public static readonly CountryType NewZealand = new CountryType(nameof(NewZealand), "NZL");
        private CountryType(string displayName, string value) : base(displayName, value) { }
    }
}
