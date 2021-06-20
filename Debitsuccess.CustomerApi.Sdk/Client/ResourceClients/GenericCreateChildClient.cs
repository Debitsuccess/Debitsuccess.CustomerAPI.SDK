using Debitsuccess.CustomerApi.Sdk.Request;
using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    public class GenericCreateChildClient<TRequest, TResource, TParent> : BaseApiClient
        where TRequest : BaseRequest
        where TResource : BaseResponse
        where TParent : BaseResponse
    {
        #region Constructors
        public GenericCreateChildClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public GenericCreateChildClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion

        #region Create Methods
        public async Task<TResource> Create(TRequest request, int parentId)
            => await Create(request, parentId.ToString());

        public async Task<TResource> Create(TRequest request, string parentId)
        {
            return await this._apiClient.Post<TRequest, TResource, TParent>(request, parentId);
        }
        #endregion
    }
}
