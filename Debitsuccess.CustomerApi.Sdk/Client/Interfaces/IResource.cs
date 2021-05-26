using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;
using Debitsuccess.CustomerApi.Sdk.Enums;

namespace Debitsuccess.CustomerApi.Sdk.Client.Interfaces
{
    public interface IGetResource<TResource> where TResource : BaseResponse
    {

        public async Task<TResource> Get(int id) => await Get(id.ToString());
        public Task<TResource> Get(string id);
    }

    public interface IGetResources<TResource, TResources> 
        where TResource : BaseResponse
        where TResources: IGetAll<TResource>
    {
        public Task<TResources> GetAll(params QueryParameterType[] queryParameters);
    }

    public interface ICreateResource<TResource> where TResource : BaseResponse
    {
        public Task<TResource> Create(TResource resourceRequest);
    }

    public interface ICreateResource<RQ, RS> where RQ : new() where RS : BaseResponse
    {
        public Task<RS> Create(RQ resourceRequest);
    }

    public interface IUpdateResource<TResource>
        where TResource : BaseResponse
    {
        public Task<TResource> Update(TResource resourceRequest, string resourceId);
    }

    public interface IUpdateResource<TUpdateResource, TResource>
        where TUpdateResource : Request.BaseRequest
        where TResource : BaseResponse
    {
        public async Task<TResource> Update(TUpdateResource resourceRequest, int resourceId) 
            => await Update(resourceRequest, resourceId.ToString());
        public Task<TResource> Update(TUpdateResource resourceRequest, string resourceId);
    }

    public interface IDeleteResourse<TResource> where TResource : BaseResponse
    {
        public Task<TResource> Delete(string id);
    }
}
