using Debitsuccess.CustomerApi.Sdk.Client.Interfaces;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    public class ScheduleClient<TResource, TResources, TParent> : BaseApiClient,
        ICreateChildResource<TResource, TParent>,
        IGetChildResource<TResource, TParent>,
        IGetChildResources<TResources, TResource, TParent>,
        IDeleteChildResourse<TResource, TParent>
        where TResources : BaseResponse, IGetAll<TResource>
        where TResource : BaseResponse
        where TParent : BaseResponse
    {
        #region Constructors
        public ScheduleClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public ScheduleClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion

        #region Create Methods
        public async Task<TResource> Create(TResource request, int parentId)
            => await Create(request, parentId.ToString());

        public async Task<TResource> Create(TResource request, string parentId)
        {
            return await this._apiClient.Post<TResource, TParent>(request, parentId);
        }
        #endregion

        #region GET Methods
        public async Task<TResource> Get(int id, int parentId)
            => await Get(id.ToString(), parentId.ToString());

        public async Task<TResource> Get(string id, string parentId)
        {
            return await this._apiClient.Get<TResource, TParent>(id, parentId);
        }

        public async Task<TResources> GetAll(int parentId, params QueryParameterType[] queryParameters) => await GetAll(parentId.ToString(), queryParameters);

        public async Task<TResources> GetAll(string parentId, params QueryParameterType[] queryParameters)
        {
            return await this._apiClient.GetAll<TResource, TResources, TParent>(parentId, queryParameters);
        }
        #endregion

        #region Delete Methods
        public async Task<DeleteResponse> Delete(int resourceId, int parentId)
             => await Delete(resourceId.ToString(), parentId.ToString());

        public async Task<DeleteResponse> Delete(string resourceId, string parentId)
        {
            return await this._apiClient.Delete<TResource, TParent>(resourceId, parentId);
        }
        #endregion
    }
}
