using Debitsuccess.CustomerApi.Sdk.Client.Interfaces;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using RestSharp;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    public class AccountClient: BaseApiClient,
        IGetResource<Account>,
        IGetResources<Account, Accounts>,
        IUpdateResource<UpdateAccount>,
        ICreateResource<Request.CreateAccount, Response.CreateAccount>
    {

        #region Constructors
        public AccountClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public AccountClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion

        /// <summary>
        /// Create an account in the Debitsuccess system
        /// </summary>
        /// <param name="resourceRequest">Create an account request<see cref="Request.CreateAccount"/></param>
        /// <returns>Returns an account which was created <see cref="Response.CreateAccount"/></returns>
        public async Task<Response.CreateAccount> Create(Request.CreateAccount resourceRequest)
        {
            var request = new RestRequest(ApiHelpers.GetResourceName<Response.CreateAccount>(), Method.POST).AddJsonBody(resourceRequest);
            return await this._apiClient.CallApi<Response.CreateAccount>(request).ConfigureAwait(false);
        }

        public async Task<Account> Get(string accountId)
        {
            return await this._apiClient.Get<Account>(accountId).ConfigureAwait(false);
        }

        public async Task<Accounts> GetAll(params QueryParameterType[] queryParameters)
        {
            return await this._apiClient.GetAll<Account, Accounts>(queryParameters).ConfigureAwait(false);
        }

        public async Task<UpdateAccount> Update(UpdateAccount resource, string accountId)
        {
            return await this._apiClient.Put<UpdateAccount>(resource, accountId).ConfigureAwait(false);
        }

        public async Task<PatchAccount> Patch(Request.PatchAccount patchRequest, string accountId)
        {
            return await this._apiClient.Patch<Request.PatchAccount, Response.PatchAccount>(patchRequest, accountId);
        }

        public async Task<DeleteResponse> Close(Request.CloseAccount deleteRequest, string accountId)
        {
            var request = new RestRequest($"ApiHelpers.GetResourceName<Account>()/{accountId}/close", Method.POST).AddJsonBody(deleteRequest);
            return await this._apiClient.CallApi<DeleteResponse>(request);
        }
    }
}
