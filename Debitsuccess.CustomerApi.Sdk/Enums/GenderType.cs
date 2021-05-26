namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    /// <summary>
    /// Represents possible genders in Debitsuccess Customer API
    /// male, female, unspecified, non-binary
    /// <seealso cref="https://debitsuccess.stoplight.io/docs/debitsuccess-api/CustomerServicesApi.yaml/paths/~1customers/post"/>
    /// </summary>
    public class GenderType: Enumeration
    {
        public static readonly GenderType Male = new GenderType(nameof(Male), "male");
        public static readonly GenderType Female = new GenderType(nameof(Female), "female");
        public static readonly GenderType Unspecified = new GenderType(nameof(Unspecified), "unspecified");
        public static readonly GenderType NonBinary = new GenderType(nameof(NonBinary), "non-binary");
        private GenderType(string displayName, string value) : base(displayName, value) { }
    }
}
