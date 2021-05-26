using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.Interfaces
{
    public interface ICreateChildResource<TResource, TParent>
        where TResource : BaseResponse
        where TParent : BaseResponse
    {
        public Task<TResource> Create(TResource request, int parentId);
        public Task<TResource> Create(TResource request, string parentId);
    }

        public interface IGetChildResource<TResource, TParent>
        where TResource : BaseResponse
        where TParent : BaseResponse
    {
        public async Task<TResource> Get(int id, int parentId)
            => await Get(id.ToString(), parentId.ToString());
        public Task<TResource> Get(string id, string parentId);
    }

    public interface IGetChildResources<TResources, TResource, TParent>
        where TResources : IGetAll<TResource>
        where TResource: BaseResponse
        where TParent : BaseResponse
    {
        public async Task<TResources> GetAll(int parentId, params QueryParameterType[] queryParameters)
            => await GetAll(parentId.ToString(), queryParameters);
        public Task<TResources> GetAll(string parentId, params QueryParameterType[] queryParameters);
    }

    public interface IUpdateChildResource<TResource>
        where TResource : BaseResponse
    {
        public async Task<TResource> Update(TResource resourceRequest, int resourceId, int parentId)
            => await Update(resourceRequest, resourceId.ToString(), parentId.ToString());
        public Task<TResource> Update(TResource resourceRequest, string resourceId, string parentId);
    }

    public interface IDeleteChildResourse<TResource, TParent>
        where TResource : BaseResponse
        where TParent : BaseResponse
    {
        public async Task<DeleteResponse> Delete(int resourceId, int parentId)
            => await Delete(resourceId.ToString(), parentId.ToString());
        public Task<DeleteResponse> Delete(string resourceId, string parentId);
    }
}
