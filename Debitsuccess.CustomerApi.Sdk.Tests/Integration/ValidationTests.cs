using Debitsuccess.CustomerApi.Sdk.Client;
using Debitsuccess.CustomerApi.Sdk.Tests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Tests.Integration
{
    [TestClass]
    public class ValidationTests
    {
        private static ApiConnectionSettings _apiSettings;
        private static CustomerApiClient _dsCustomerApiClient;

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _apiSettings = ConfigurationHelper.GetApiConnectionSettings();
            _dsCustomerApiClient = new CustomerApiClient(_apiSettings);
        }

        [TestMethod]
        public async Task CreateCustomerShouldReturnErrorIfBadRequest()
        {
            // Arrange
            var requestModel = TestDataHelper.GetCreateCustomerValidRequest(7211);
            requestModel.DateOfBirth = DateTime.Now.AddYears(-500);
            // Act
            try
            {
                var response = await _dsCustomerApiClient.Customers.Create(requestModel);
            }
            catch (Exception ex)
            {
                // Assert
                Assert.IsTrue(ex is CustomerApiException);
            }
        }
    }
}
