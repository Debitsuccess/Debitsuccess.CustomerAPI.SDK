using Debitsuccess.CustomerApi.Sdk.Client.Interfaces;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    /// <summary>
    /// Generic API client to execute Get All call only
    /// Debitsuccess Customer API has some endpoints which supports GET
    /// but doesn't support GET by Id
    /// </summary>
    public class GenericGetAllClient<TResource, TResources> : BaseApiClient,
        IGetResources<TResource, TResources>
        where TResource : BaseResponse where TResources : IGetAll<TResource>
    {
        #region Constructors
        public GenericGetAllClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public GenericGetAllClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion
        public async Task<TResources> GetAll(params QueryParameterType[] queryParameters)
        {
            return await this._apiClient.GetAll<TResource, TResources>(queryParameters).ConfigureAwait(false);
        }
    }
}
