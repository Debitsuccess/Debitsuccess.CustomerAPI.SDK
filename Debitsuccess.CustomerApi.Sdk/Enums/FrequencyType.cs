namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    /// <summary>
    /// Represents a list of possible frequencies in Debitsuccess system
    /// weekly, fortnightly, four-weekly, monthly, bi-monthly, quarterly
    /// <seealso cref="https://debitsuccess.stoplight.io/docs/debitsuccess-api/CustomerServicesApi.yaml/paths/~1accounts/post"/>
    /// </summary>
    public class FrequencyType: Enumeration
    {
        public static readonly FrequencyType Weekly = new FrequencyType(nameof(Weekly), "weekly");
        public static readonly FrequencyType Fortnightly = new FrequencyType(nameof(Fortnightly), "fortnightly");
        public static readonly FrequencyType FourWeekly = new FrequencyType(nameof(FourWeekly), "four-weekly");
        public static readonly FrequencyType Monthly = new FrequencyType(nameof(Monthly), "monthly");
        public static readonly FrequencyType BiMonthly = new FrequencyType(nameof(BiMonthly), "bi-monthly");
        public static readonly FrequencyType Quarterly = new FrequencyType(nameof(Quarterly), "quarterly");
        private FrequencyType(string displayName, string value) : base(displayName, value) { }
    }
}
