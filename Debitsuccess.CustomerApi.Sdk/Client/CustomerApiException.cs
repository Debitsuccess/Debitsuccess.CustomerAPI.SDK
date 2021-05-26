using Debitsuccess.CustomerApi.Sdk.Response;
using System;

namespace Debitsuccess.CustomerApi.Sdk.Client
{
    public class CustomerApiException: Exception
    {
        public CustomerApiException() : base()
        {
        }

        public CustomerApiException(DsErrorResponse dsErrorResponse) : base()
        {
            DsErrorResponse = dsErrorResponse;
        }

        public CustomerApiException(DsErrorResponse dsErrorResponse, string message) : base(message)
        {
            DsErrorResponse = dsErrorResponse;
        }

        public CustomerApiException(string message) : base(message)
        {
        }

        public CustomerApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public DsErrorResponse DsErrorResponse { get; set; }
    }
}
