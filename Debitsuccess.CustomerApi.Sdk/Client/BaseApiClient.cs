namespace Debitsuccess.CustomerApi.Sdk.Client
{
    public class BaseApiClient
    {
        internal DsApiClient _apiClient;
        public BaseApiClient(ApiConnectionSettings apiConnectionSettings)
        {
            this._apiClient = new DsApiClient(apiConnectionSettings);
        }

        public BaseApiClient(DsApiClient apiClient)
        {
            this._apiClient = apiClient;
        }
    }
}