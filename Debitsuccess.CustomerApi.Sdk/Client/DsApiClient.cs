using Serilog;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;
using RestSharp.Serializers.Utf8Json;
using Utf8Json;
using Utf8Json.Resolvers;
using Debitsuccess.CustomerApi.Sdk.Response;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Request;
using System;

namespace Debitsuccess.CustomerApi.Sdk.Client
{
    public class DsApiClient
    {
        private JwtAuthenticator _jwtAuthenticator;
        private readonly JwtProvider _jwtProvider;
        private readonly ApiConnectionSettings _apiSettings;
        private readonly ILogger _logger;
        private RestClient _restClient;

        public DsApiClient(ApiConnectionSettings apiSettings)
        {
            this._logger ??= new LoggerConfiguration()
                                    .WriteTo.Console()
                                    .CreateLogger();
            this._jwtProvider = new JwtProvider(apiSettings, _logger);
            this._apiSettings = apiSettings;
            InitialiseRestClient().Wait();
        }

        public DsApiClient(ApiConnectionSettings identitySettings, ILogger logger) : this(identitySettings)
        {
            this._logger = logger;
        }

        #region Generic Methods

        /// <summary>
        /// Execute a generic POST request to API to create a sub-resource. This method should be used
        /// to create child entities when request and response have different structures
        /// </summary>
        /// <typeparam name="TRequest">Any request inherited from <see cref="BaseRequest"/></typeparam>
        /// <typeparam name="TResponse">Any response inherited from <see cref="BaseResponse"/></typeparam>
        /// <typeparam name="TParent">Type of the parent entity inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="request">Any request inherited from <see cref="BaseRequest"/></param>
        /// <param name="parentId">An unique identifier of the parent resource</param>
        /// <returns></returns>
        public async Task<TResponse> Post<TRequest, TResponse, TParent>(TRequest request, string parentId)
            where TRequest : BaseRequest
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            var apiRequest = new RestRequest(
                                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}/"
                                , Method.POST).AddJsonBody(request);
            return await CallApi<TResponse>(apiRequest);
        }

        /// <summary>
        /// Execute a generic POST request to API to create a resource. This method is not suitable for
        /// creating composite entities (<see cref="Request.CreateCustomer"/>Customer</see>/Account)
        /// </summary>
        /// <typeparam name="TResponse">Any response inherited from <see cref="BaseResponse">BaseResponse</see>/></typeparam>
        /// <param name="resource"></param>
        /// <returns>Resource which had been created</returns>
        public async Task<TResponse> Post<TResponse>(TResponse resource) 
            where TResponse : BaseResponse
        {
            var request = new RestRequest(ApiHelpers.GetResourceName<TResponse>(), Method.POST).AddJsonBody(resource);
            return await CallApi<TResponse>(request);
        }

        /// <summary>
        /// Execute a generic POST request to API to create a sub-resource. This method should be used
        /// to create child entities (Customer/Account)
        /// </summary>
        /// <typeparam name="TResponse">Any response inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="resource"></param>
        /// <returns>Resource which had been created</returns>
        public async Task<TResponse> Post<TResponse, TParent>(TResponse resource, string parentId)
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            var request = new RestRequest(
                                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}/"
                                , Method.POST).AddJsonBody(resource);
            return await CallApi<TResponse>(request);
        }

        /// <summary>
        /// Execute generic PATCH request to API
        /// </summary>
        /// <typeparam name="TPatchRequest"></typeparam>
        /// <typeparam name="TResponse">Generic patch response inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="patchRequest">Concrete patch request</param>
        /// <param name="resourceId">An unique identifier of the resource needs to be patched</param>
        /// <returns>Path response of type inherited from <see cref="BaseResponse"/></returns>
        public async Task<TResponse> Patch<TPatchRequest, TResponse>(TPatchRequest patchRequest, string resourceId)
            where TPatchRequest : BaseRequest
            where TResponse : BaseResponse
        {
            var request = new RestRequest($"{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}", Method.PATCH).AddJsonBody(patchRequest);
            return await CallApi<TResponse>(request);
        }

        /// <summary>
        /// Execute generic PATCH request to a child resource
        /// </summary>
        /// <typeparam name="TPatchRequest">Patch request object</typeparam>
        /// <typeparam name="TResponse">Generic patch response inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="patchRequest">Concrete patch request</param>
        /// <param name="resourceId">An unique identifier of the resource needs to be patched</param>
        /// <param name="parentId">An unique identifier of the parent resource</param>
        /// <returns>Path response of type inherited from <see cref="BaseResponse"/></returns>
        public async Task<TResponse> Patch<TPatchRequest, TResponse, TParent>(TPatchRequest patchRequest, string resourceId, string parentId)
            where TPatchRequest : BaseRequest
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            var request = new RestRequest(
                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}"
                , Method.PATCH)
                .AddJsonBody(patchRequest);
            return await CallApi<TResponse>(request);
        }

        /// <summary>
        /// Execute a generic PUT request to API where request and response have the same structure
        /// </summary>
        /// <typeparam name="TResponse">Generic update response inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="resourceRequest">Concrete update request</param>
        /// <returns>Resource which had been updated</returns>
        public async Task<TResponse> Put<TResponse>(TResponse resourceRequest, string resourceId)
            where TResponse : BaseResponse
        {
            var request = new RestRequest($"{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}", Method.PUT).AddJsonBody(resourceRequest);
            return await CallApi<TResponse>(request);
        }

        /// <summary>
        /// Execute a generic PUT request to API where request and response have the same structure
        /// </summary>
        /// <typeparam name="TResponse">Generic update response inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="resourceRequest">Concrete update request</param>
        /// <returns>Resource which had been updated</returns>
        public async Task<TResponse> Put<TResponse, TParent>(TResponse resourceRequest, string resourceId, string parentId)
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            var request = new RestRequest(
                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}"
                , Method.PUT)
                .AddJsonBody(resourceRequest);
            return await CallApi<TResponse>(request);
        }

        /// <summary>
        /// Execute a generic PUT request to API where request and response have different structure
        /// </summary>
        /// <typeparam name="TUpdateRequest">Generic update request inherited from <see cref="BaseRequest"/></typeparam>
        /// <typeparam name="TResponse">Generic update response inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="resourceRequest">Concrete update request</param>
        /// <returns>Resource which had been updated</returns>
        public async Task<TResponse> Put<TUpdateRequest, TResponse>(TUpdateRequest resourceRequest, string resourceId)
            where TUpdateRequest : BaseRequest
            where TResponse : BaseResponse
        {
            var request = new RestRequest($"{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}", Method.PUT).AddJsonBody(resourceRequest);
            return await CallApi<TResponse>(request);
        }

        #region Delete Methods
        public async Task<TResponse> Delete<TResponse>(string resourceId)
            where TResponse : BaseResponse
        {
            var request = new RestRequest($"{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}", Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            return await CallApi<TResponse>(request);
        }

        public async Task<DeleteResponse> Delete<TResponse, TParent>(string resourceId, string parentId)
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            var request = new RestRequest(
                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}",
                Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            return await CallApi<DeleteResponse>(request);
        }
        #endregion

        #region GET Methods

        /// <summary>
        /// Execute a generic GET request to API to get a default resource
        /// from the parent resouce
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TParent"></typeparam>
        /// <param name="parentId"></param>
        /// <returns>The requested resource of type inherited from <see cref="BaseResponse"/></returns>
        public async Task<TResponse> GetDefault<TResponse, TParent>(string parentId)
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            var request = new RestRequest(
                                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}"
                                , Method.GET);
            return await CallApi<TResponse>(request);
        }
        /// <summary>
        /// Execute a generic GET request to API.
        /// </summary>
        /// <typeparam name="TResponse">Any response inherited from <see cref="BaseResponse"/></typeparam>
        /// <param name="resourceId">A unique identifier of the resource</param>
        /// <returns>Resource with a specified Id of type inherited from <see cref="BaseResponse"/></returns>
        public async Task<TResponse> Get<TResponse>(string resourceId)
            where TResponse : BaseResponse
        {
            var request = new RestRequest($"{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            return await CallApi<TResponse>(request);
        }

        /// <summary>
        /// Execute a generic GET request to API to get a child resource
        /// </summary>
        /// <typeparam name="TResponse">The type of resource needs to be returned</typeparam>
        /// <typeparam name="TParent">The type of the parent resource</typeparam>
        /// <param name="resourceId">An unique identifier of the resource to return</param>
        /// <param name="parentId">An unique identifier of the parent resource</param>
        /// <returns>The requested resource of type inherited from <see cref="BaseResponse"/></returns>
        public async Task<TResponse> Get<TResponse, TParent>(string resourceId, string parentId)
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            var request = new RestRequest(
                                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}/{resourceId}"
                                , Method.GET);
            return await CallApi<TResponse>(request);
        }

        public async Task<TResponses> GetAll<TResponse, TResponses>(params QueryParameterType[] queryParameters)
            where TResponse : BaseResponse
            where TResponses : IGetAll<TResponse>
        {
            var request = new RestRequest($"{ApiHelpers.GetResourceName<TResponse>()}", Method.GET);
            if (queryParameters != null)
            {
                for (var i = 0; i < queryParameters.Length; ++i)
                {
                    request.AddQueryParameter(queryParameters[i].Name, queryParameters[i].Value);
                }
            }
            request.RequestFormat = DataFormat.Json;
            return await CallGetAllApi<TResponse, TResponses>(request);
        }

        public async Task<TResponses> GetAll<TResponse, TResponses, TParent>(string parentId, params QueryParameterType[] queryParameters)
            where TResponses: IGetAll<TResponse>
            where TResponse : BaseResponse
            where TParent : BaseResponse
        {
            //await UpdateBearer();
            var request = new RestRequest(
                                $"{ApiHelpers.GetResourceName<TParent>()}/{parentId}/{ApiHelpers.GetResourceName<TResponse>()}"
                                , Method.GET);
            if(queryParameters != null)
            {
                for (var i = 0; i < queryParameters.Length; ++i)
                {
                    request.AddQueryParameter(queryParameters[i].Name, queryParameters[i].Value);
                }
            }
            request.RequestFormat = DataFormat.Json;
            return await CallGetAllApi<TResponse, TResponses>(request);
        }
        #endregion

        public async Task<TResponses> CallGetAllApi<TResponse, TResponses>(IRestRequest request)
            where TResponses : IGetAll<TResponse> 
            where TResponse: BaseResponse
        {
            await UpdateBearer();
            var response = await this._restClient.ExecuteAsync<TResponse>(request);
            if (!response.IsSuccessful)
            {
                var errorResponse = new DsErrorResponse();
                try
                {
                    errorResponse = JsonSerializer.Deserialize<DsErrorResponse>(response.Content);
                }
                catch(Exception ex)
                {
                    _logger.Error($"Could not deserialize unsuccessful response. The response code {(int)response.StatusCode}. The response: {response.Content}", ex);
                }
                errorResponse.StatusCode = (int)response.StatusCode;
                throw new CustomerApiException(errorResponse, response.ErrorMessage);
            }
            try
            {
                var result = JsonSerializer.Deserialize<TResponses>(response.Content);
                result.StatusCode = (int)response.StatusCode;
                return result;
            }
            catch(Exception ex)
            {
                this._logger.Error($"Could not deserialize response. The response code {(int)response.StatusCode}. The response: {response.Content}", ex);
                throw;
            }
        }

        public async Task<TResponse> CallApi<TResponse>(IRestRequest request) where TResponse : BaseResponse
        {
            await UpdateBearer();
            var response = await this._restClient.ExecuteAsync<TResponse>(request);
            if (!response.IsSuccessful)
            {
                var errorResponse = new DsErrorResponse();
                try
                {
                    errorResponse = JsonSerializer.Deserialize<DsErrorResponse>(response.Content);
                }
                catch (Exception ex)
                {
                    _logger.Error($"Could not deserialize response. The response code {(int)response.StatusCode}. The response: {response.Content}", ex);
                }
                errorResponse.StatusCode = (int)response.StatusCode;
                throw new CustomerApiException(errorResponse, response.ErrorMessage);
            }
            try
            {
                var result = JsonSerializer.Deserialize<TResponse>(response.Content);
                result.StatusCode = (int)response.StatusCode;
                return result;
            }
            catch (Exception ex)
            {
                this._logger.Error($"Could not deserialize response. The response code {(int)response.StatusCode}. The response: {response.Content}", ex);
                throw;
            }
        }
        #endregion

        #region Rest Client Headers Configuration
        private async Task InitialiseRestClient()
        {
            this._restClient = new RestClient(_apiSettings.CustomerApiUrl);
            this._jwtAuthenticator = new JwtAuthenticator(await this._jwtProvider.GetAuthToken());
            this._restClient.Authenticator = this._jwtAuthenticator;
            this._restClient.UseUtf8Json();
            JsonSerializer.SetDefaultResolver(StandardResolver.CamelCase);
        }

        private async Task UpdateBearer()
        {
            this._jwtAuthenticator.SetBearerToken(await this._jwtProvider.GetAuthToken());
            this._restClient.Authenticator = this._jwtAuthenticator;
        }
        #endregion
    }
}
