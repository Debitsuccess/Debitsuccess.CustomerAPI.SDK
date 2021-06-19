using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    public class GenericGetDefaultClient<TResource, TParent> : BaseApiClient
        where TResource : BaseResponse
        where TParent : BaseResponse
    {
        #region Constructors
        public GenericGetDefaultClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public GenericGetDefaultClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion
        public async Task<TResource> Get(string parentId)
        {
            return await this._apiClient.GetDefault<TResource, TParent>(parentId);
        }
    }
}
