using Debitsuccess.CustomerApi.Sdk.Client;
using Debitsuccess.CustomerApi.Sdk.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Tests.Integration
{
    /// <summary>
    /// This class is for internal purposes, cause one time payment token
    /// cannot be generated via API call. To get a token we need to use a capture widget
    /// https://debitsuccess.stoplight.io/docs/debitsuccess-api/docs/Widgets/Payment-Capture-Widget.md
    /// </summary>
    [TestClass]
    public class PatchIntegrationTests
    {
        private static ApiConnectionSettings _apiConnectionSettings;
        private static CustomerApiClient _dsCustomerApiClient;
        private static int _customerId = 0; //add customer id for testing like = 1234567;
        private static string _accountId = "";  //add customer id for testing like= "DEA28888888";
        private static string _oneTimePaymentMethodToken = ""; // add one time payment token for testing like = "f41bd79d-55c1-4d55-92d7-891d981534e2";
        private static string _paymentMethodToken;

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _apiConnectionSettings = ConfigurationHelper.GetApiConnectionSettings();
            _dsCustomerApiClient = new CustomerApiClient(_apiConnectionSettings);
        }

        [TestMethod]
        [Ignore] // Remove after testing properties are set
        public async Task Test0001_PatchCustomerShouldBeSuccessful()
        {
            // Arrange
            var request = new PatchCustomer()
            { 
                OneTimePaymentMethodToken = _oneTimePaymentMethodToken
            };
            // Act
            var result = await _dsCustomerApiClient.Customers.Patch(request, _customerId);
            // Assert          
            Assert.IsNotNull(result);
            _paymentMethodToken = result.PaymentMethodToken;
        }

        [TestMethod]
        [Ignore] // Remove after testing properties are set
        public async Task Test0002_PatchAccountShouldBeSuccessful()
        {
            // Arrange
            var request = new PatchAccount()
            {
                PaymentMethodToken = _paymentMethodToken
            };
            // Act
            var result = await _dsCustomerApiClient.Accounts.Patch(request, _accountId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.AccountId.Equals(_accountId, StringComparison.OrdinalIgnoreCase));
        }
    }
}
