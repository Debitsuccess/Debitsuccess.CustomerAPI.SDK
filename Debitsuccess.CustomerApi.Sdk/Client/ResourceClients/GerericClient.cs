using Debitsuccess.CustomerApi.Sdk.Client.Interfaces;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    public class GerericClient<TResource, TResources> : BaseApiClient,
        IGetResource<TResource>,
        IGetResources<TResource, TResources>,
        IUpdateResource<TResource>,
        ICreateResource<TResource>,
        IDeleteResourse<TResource> where TResource : BaseResponse where TResources: IGetAll<TResource>
    {
        public GerericClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public GerericClient(DsApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<TResource> Create(TResource resourceRequest)
        {
            return await this._apiClient.Post<TResource>(resourceRequest).ConfigureAwait(false);
        }

        public async Task<TResource> Delete(string id)
        {
            return await this._apiClient.Delete<TResource>(id);
        }

        public async Task<TResource> Get(string id)
        {
            return await this._apiClient.Get<TResource>(id).ConfigureAwait(false);
        }

        public async Task<TResources> GetAll(params QueryParameterType[] queryParameters)
        {
            return await this._apiClient.GetAll<TResource, TResources>(queryParameters).ConfigureAwait(false);
        }

        public async Task<TResource> Update(TResource resource, string resourceId)
        {
            return await this._apiClient.Put<TResource>(resource, resourceId).ConfigureAwait(false);
        }
    }
}
