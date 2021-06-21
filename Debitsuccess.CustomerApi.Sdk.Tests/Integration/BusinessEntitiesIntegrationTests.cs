using Debitsuccess.CustomerApi.Sdk.Client;
using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Response;
using Debitsuccess.CustomerApi.Sdk.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Tests.Integration
{
    [TestClass]
    public class BusinessEntitiesIntegrationTests
    {
        private static ApiConnectionSettings _apiConnectionSettings;
        private static ApiSettings _apiSettings;
        private static CustomerApiClient _dsCustomerApiClient;
        private static int _businessId;
        private static string _businessAccountId;

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _apiSettings = ConfigurationHelper.GetApiSettings();
            _apiConnectionSettings = ConfigurationHelper.GetApiConnectionSettings();
            _dsCustomerApiClient = new CustomerApiClient(_apiConnectionSettings);
        }

        [TestMethod]
        public async Task Test0001_GetBusinessesShouldBeSuccessful()
        {
            // Arrange
            // Act
            var response = await _dsCustomerApiClient.Businesses.GetAll();
            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Elements); 
            Assert.IsTrue(response.Elements.Count >= 1);
            _businessId = response.Elements[0].BusinessId;
        }

        [TestMethod]
        public async Task Test0002_GetBusinessByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var response = await _dsCustomerApiClient.Businesses.Get(_businessId);
            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.BusinessId == _businessId);
        }

        [TestMethod]
        public async Task Test1001_GetBusinessAccountsShouldBeSuccessful()
        {
            // Arrange
            // Act
            var response = await _dsCustomerApiClient.BusinessAccounts.GetAll();
            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Elements);
            Assert.IsTrue(response.Elements.Count >= 1);
            _businessAccountId = response.Elements[0].BusinessAccountId;
        }

        [TestMethod]
        public async Task Test1002_GetBusinessAccountByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var response = await _dsCustomerApiClient.BusinessAccounts.Get(_businessAccountId);
            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.BusinessAccountId.Equals(_businessAccountId, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public async Task Test2001_GetTermsAndConditionsByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var response = await _dsCustomerApiClient.TermsAndConditions.Get(_businessAccountId);
            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.BusinessAccountId.Equals(_businessAccountId, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public async Task Test3001_CreateCasualPaymentTokenShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetCreateCasualPaymentTokenValidRequest(_businessAccountId);
            // Act
            var response = await _dsCustomerApiClient.CasualPaymentToken.Create(request, _businessAccountId);
            // Assert
            Assert.IsNotNull(response);
        }
    }
}
