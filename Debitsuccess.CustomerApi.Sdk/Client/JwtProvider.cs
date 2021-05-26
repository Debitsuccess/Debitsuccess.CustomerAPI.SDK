using IdentityModel.Client;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;
using Serilog;

namespace Debitsuccess.CustomerApi.Sdk.Client
{
    public class JwtProvider
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly ApiConnectionSettings _identitySettings;
        private TokenResponse _cachedTokenResponse;
        private ILogger _logger;
        public JwtProvider(ApiConnectionSettings identitySettings)
        {
            this._identitySettings = identitySettings;
            this._logger ??= new LoggerConfiguration()
                                    .WriteTo.Console()
                                    .CreateLogger();
        }

        public JwtProvider(ApiConnectionSettings identitySettings, ILogger logger): this(identitySettings)
        {
            this._logger = logger;
        }
        
        public async Task<string> GetAuthToken()
        {
            var token = await GetTokenResponse().ConfigureAwait(false);
            return token.AccessToken;
        }

        private async Task<TokenResponse> GetTokenResponse()
        {
            if (!string.IsNullOrEmpty(this._cachedTokenResponse?.AccessToken))
            {
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var token = jwtSecurityTokenHandler.ReadJwtToken(this._cachedTokenResponse?.AccessToken);
                if (token.ValidTo <= DateTime.Now.AddMinutes(-1))
                {
                    return this._cachedTokenResponse;
                }
            }
            var discovery = await _httpClient.GetDiscoveryDocumentAsync(this._identitySettings.IdentityUrl).ConfigureAwait(false);
            if (discovery.IsError)
            {
                _logger.Error(discovery.Error);
            }

            // request token
            this._cachedTokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discovery.TokenEndpoint,
                ClientId = this._identitySettings.ClientId,
                ClientSecret = this._identitySettings.ClientSecret
            });

            return this._cachedTokenResponse;
        }
    }
}
