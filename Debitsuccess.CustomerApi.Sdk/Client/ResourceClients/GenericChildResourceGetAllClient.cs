using Debitsuccess.CustomerApi.Sdk.Client.Interfaces;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    /// <summary>
    /// Generic API client to execute Get All for a child resource only
    /// Debitsuccess Customer API has some endpoints which supports GET
    /// but doesn't support GET by Id
    /// </summary>
    public class GenericChildResourceGetAllClient<TResource, TResources, TParent> : BaseApiClient,
        IGetChildResources<TResources, TResource, TParent>
        where TResources : BaseResponse, IGetAll<TResource>
        where TResource : BaseResponse
        where TParent : BaseResponse
    {
        #region Constructors
        public GenericChildResourceGetAllClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public GenericChildResourceGetAllClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion
        #region GET Methods
        public async Task<TResources> GetAll(int parentId, params QueryParameterType[] queryParameters)
            => await GetAll(parentId.ToString(), queryParameters);
        public async Task<TResources> GetAll(string parentId, params QueryParameterType[] queryParameters)
        {
            return await this._apiClient.GetAll<TResource, TResources, TParent>(parentId, queryParameters);
        }
        #endregion
    }
}
