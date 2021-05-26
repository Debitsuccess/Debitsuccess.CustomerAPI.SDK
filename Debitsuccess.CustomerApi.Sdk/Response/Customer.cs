using Debitsuccess.CustomerApi.Sdk.Formatter;
using System;
using Utf8Json;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class Customer: BaseCustomer
    {
        public Business Business { get; set; }
    }
}