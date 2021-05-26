namespace Debitsuccess.CustomerApi.Sdk.Enums
{
    public class QueryParameterType: Enumeration
    {
        public static readonly QueryParameterType AccountId = new QueryParameterType ("accountId");
        public static readonly QueryParameterType BusinessId = new QueryParameterType ("businessId");
        public static readonly QueryParameterType BusinessAccountId = new QueryParameterType("businessAccountId");
        public static readonly QueryParameterType FromDatetime = new QueryParameterType("fromDatetime");
        public static readonly QueryParameterType Limit = new QueryParameterType ("limit", "50");
        public static readonly QueryParameterType NextCursor = new QueryParameterType ("nextCursor", "");
        public static readonly QueryParameterType ToDatetime = new QueryParameterType("toDatetime");
        public static readonly QueryParameterType OrderAscending = new QueryParameterType("order", "Ascending");
        public static readonly QueryParameterType OrderDescending = new QueryParameterType("order", "Descending");

        private QueryParameterType () { }
        private QueryParameterType (string displayName) : base(displayName) { }
        private QueryParameterType(string displayName, string value) : base(displayName, value) { }
    }
}
