using Debitsuccess.CustomerApi.Sdk.Client.Interfaces;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    public class CustomerClient : BaseApiClient,
        IGetResource<Customer>,
        IGetResources<Customer, Customers>,
        IUpdateResource<Request.UpdateCustomer, ExtendedCustomer>,
        ICreateResource<Request.CreateCustomer, Response.CreateCustomer>
    {
        public CustomerClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public CustomerClient(DsApiClient apiClient) : base(apiClient)
        {
        }

        /// <summary>
        /// Create a Customer entity in the Debitsuccess system
        /// </summary>
        /// <param name="resourceRequest">Create a customer request object</param>
        /// <returns>Return Create Customer response <see cref="Response.CreateCustomer"/></returns>
        public async Task<Response.CreateCustomer> Create(Request.CreateCustomer resourceRequest)
        {
            var request = new RestRequest(ApiHelpers.GetResourceName<Response.CreateCustomer>(), Method.POST).AddJsonBody(resourceRequest);
            return await this._apiClient.CallApi<Response.CreateCustomer>(request).ConfigureAwait(false);
        }

        public async Task<Customer> Get(int id)
        {
            return await Get(id.ToString());
        }

        public async Task<Customer> Get(string id)
        {
            return await this._apiClient.Get<Customer>(id).ConfigureAwait(false);
        }

        public async Task<Customers> GetAll(params QueryParameterType[] queryParameters)
        {
            return await this._apiClient.GetAll<Customer, Customers>(queryParameters).ConfigureAwait(false);
        }

        public async Task<ExtendedCustomer> Update(Request.UpdateCustomer resourceRequest, int customerId)
            => await Update(resourceRequest, customerId.ToString());

        public async Task<ExtendedCustomer> Update(Request.UpdateCustomer resourceRequest, string customerId)
        {
            return await this._apiClient.Put<Request.UpdateCustomer, ExtendedCustomer>(resourceRequest, customerId);
        }

        public async Task<PaymentMethod> Patch(Request.PatchCustomer patchRequest, int customerId)
            => await Patch(patchRequest, customerId.ToString());

        public async Task<PaymentMethod> Patch(Request.PatchCustomer patchRequest, string customerId)
        {
            var request = new RestRequest(
                $"{ApiHelpers.GetResourceName<Customer>()}/{customerId}/paymentMethods"
                , Method.PATCH)
                .AddJsonBody(patchRequest);
            return await this._apiClient.CallApi<PaymentMethod>(request).ConfigureAwait(false);
        }
    }
}
