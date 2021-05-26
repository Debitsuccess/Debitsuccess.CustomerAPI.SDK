using Debitsuccess.CustomerApi.Sdk.Client;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;


namespace Debitsuccess.CustomerApi.Sdk.Tests.Integration
{
    [TestClass]
    public class GenericGetAllIntegrationTests
    {
        private static ApiConnectionSettings _apiConnectionSettings;
        private static ApiSettings _apiSettings;
        private static CustomerApiClient _dsCustomerApiClient;
        
        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _apiSettings = ConfigurationHelper.GetApiSettings();
            _apiConnectionSettings = ConfigurationHelper.GetApiConnectionSettings();
            _dsCustomerApiClient = new CustomerApiClient(_apiConnectionSettings);
        }

        [TestMethod]
        public async Task Test0001_GetAllOverdueStatusChangesShouldBeSuccessful()
        {
            // Arrange
            var queryParameters = new QueryParameterType[1];
            queryParameters[0] = QueryParameterType.OrderDescending;
            // Act
            var result = await _dsCustomerApiClient.OverdueStatusChanges.GetAll(queryParameters);
            // Assert          
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Test1001_GetAllPaymentStatusesChangesShouldBeSuccessful()
        {
            // Arrange
            var queryParameters = new QueryParameterType[1];
            queryParameters[0] = QueryParameterType.OrderDescending;
            // Act
            var result = await _dsCustomerApiClient.PaymentStatuses.GetAll(_apiSettings.BusinessId, queryParameters);
            // Assert          
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Test2001_GetAllPaymentShouldBeSuccessful()
        {
            // Arrange
            var queryParameters = new QueryParameterType[1];
            queryParameters[0] = QueryParameterType.OrderDescending;
            // Act
            var result = await _dsCustomerApiClient.Payments.GetAll(queryParameters);
            // Assert          
            Assert.IsNotNull(result);
        }
    }
}
