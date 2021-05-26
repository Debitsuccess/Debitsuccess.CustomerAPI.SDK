using Debitsuccess.CustomerApi.Sdk.Client;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Debitsuccess.CustomerApi.Sdk.Tests
{
    public static class ConfigurationHelper
    {
        private static IConfigurationRoot Configuration = null;
        public static IConfigurationRoot GetConfiguration()
        {
            Configuration ??= new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetAssembly(typeof(ApiConnectionSettings)).Location))
                .AddJsonFile("IntegrationTestSettings.json", optional: true)
                .Build();
            return Configuration;
        }

        public static ApiConnectionSettings GetApiConnectionSettings()
        {
            var config = GetConfiguration();
            var apiConnectionSettings = new ApiConnectionSettings();
            config.GetSection("ApiConnectionSettings").Bind(apiConnectionSettings);
            return apiConnectionSettings;
        }

        public static ApiSettings GetApiSettings()
        {
            var config = GetConfiguration();
            var apiSettings = new ApiSettings();
            config.GetSection("ApiSettings").Bind(apiSettings);
            return apiSettings;
        }
    }
}
