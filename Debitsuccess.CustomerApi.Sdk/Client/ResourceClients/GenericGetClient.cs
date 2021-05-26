using Debitsuccess.CustomerApi.Sdk.Client.Interfaces;
using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    /// <summary>
    /// Generic GET client for Debitsuccess Customer API
    /// It extends GET All Client and adds functionality get by resource by Id
    /// </summary>
    /// <typeparam name="TResource"></typeparam>
    /// <typeparam name="TResources"></typeparam>
    public class GenericGetClient<TResource, TResources> : GenericGetAllClient<TResource, TResources>,
        IGetResource<TResource>
        where TResource : BaseResponse where TResources : IGetAll<TResource>
    {
        #region Constructors
        public GenericGetClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public GenericGetClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion

        public async Task<TResource> Get(int id) => await Get(id.ToString());
        public async Task<TResource> Get(string id)
        {
            return await this._apiClient.Get<TResource>(id).ConfigureAwait(false);
        }
    }
}
