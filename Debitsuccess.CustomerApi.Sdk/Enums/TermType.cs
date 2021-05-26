namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    /// <summary>
    /// Represents a list of possible term types in Debitsuccess system
    /// months, payments
    /// <seealso cref="https://debitsuccess.stoplight.io/docs/debitsuccess-api/CustomerServicesApi.yaml/paths/~1accounts/post"/>
    /// </summary>
    public class TermType: Enumeration
    {
        public static readonly TermType Months = new TermType(nameof(Months), "months");
        public static readonly TermType Payments = new TermType(nameof(Payments), "payments");
        private TermType(string displayName, string value) : base(displayName, value) { }
    }
}
