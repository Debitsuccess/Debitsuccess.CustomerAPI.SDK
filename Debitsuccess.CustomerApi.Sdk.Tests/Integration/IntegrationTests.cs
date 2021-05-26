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
    public class IntegrationTests
    {
        private static ApiConnectionSettings _apiConnectionSettings;
        private static ApiSettings _apiSettings;
        private static CustomerApiClient _dsCustomerApiClient;
        private static int _customerId;
        private static int _oldEmailAddressId;
        private static int _oldPhoneNumberId;
        private static int _oldAddressId;
        private static string _accountId;
        private static string _accountExternalId;

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            _apiSettings = ConfigurationHelper.GetApiSettings();
            _apiConnectionSettings = ConfigurationHelper.GetApiConnectionSettings();
            _dsCustomerApiClient = new CustomerApiClient(_apiConnectionSettings);
        }
        
        [TestMethod]
        public async Task Test0001_CreateCustomerShouldBeSuccessful()
        {
            // Arrange
            var requestModel = TestDataHelper.GetCreateCustomerValidRequest(_apiSettings.BusinessId);
            // Act
            var response = await _dsCustomerApiClient.Customers.Create(requestModel);
            // Assert
            _customerId = response.CustomerId;
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task Test0002_GetCustomerByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var response = await _dsCustomerApiClient.Customers.Get(_customerId);
            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task Test0003_CustomersGetAllShouldReturnSuccess()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.Customers.GetAll();
            // Assert
            Assert.IsNotNull(result as IGetAll<Customer>);
            Assert.IsNotNull(result.Elements);
            Assert.IsNotNull(result.ResponseMetadata);
        }

        [TestMethod]
        public async Task Test0004_CustomersGetAllShouldRespectLimit()
        {
            // Arrange
            var queryParameters = new QueryParameterType[1];
            var limit = QueryParameterType.Limit;
            limit.SetValue("1");
            queryParameters[0] = limit; 
            // Act
            var result = await _dsCustomerApiClient.Customers.GetAll(queryParameters);
            // Assert
            Assert.IsTrue(result.Elements.Count == 1);
        }

        [TestMethod]
        public async Task Test0005_UpdateCustomerShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetUpdateCustomerValidRequest();
            request.Gender = GenderType.Female.Value;
            request.MiddleName = "SDK";
            // Act
            var result = await _dsCustomerApiClient.Customers.Update(request, _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.MiddleName.Equals("SDK", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.Gender.Equals(GenderType.Female.Value, StringComparison.OrdinalIgnoreCase));
        }

        #region Email Address tests
        [TestMethod]
        public async Task Test1001_GetAllEmailAddressesShouldReturnSuccess()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.EmailAddresses.GetAll(_customerId);            
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result as IGetAll<EmailAddress>);
            Assert.IsNotNull(result.ResponseMetadata);
            Assert.IsTrue(result.Elements.Count >= 1);
            _oldEmailAddressId = result.Elements[0].EmailAddressId;
        }

        [TestMethod]
        public async Task Test1002_GetEmailAddressByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.EmailAddresses.Get(id: _oldEmailAddressId, parentId: _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test1003_CreateEmailAddressShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetEmailAddressValidRequest();
            // Act
            var result = await _dsCustomerApiClient.EmailAddresses.Create(request, _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.EmailName.Equals(request.EmailName, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test1004_UpdateEmailAddressShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetUpdateEmailAddressValidRequest();
            // Act
            var result = await _dsCustomerApiClient.EmailAddresses.Update(request, _oldEmailAddressId, _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test1005_DeleteEmailAddressShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.EmailAddresses.Delete(_oldEmailAddressId, _customerId);
            // Assert
            Assert.IsNotNull(result);
        }
        #endregion

        #region Phone Number tests
        [TestMethod]
        public async Task Test2001_GetAllPhoneNumbersShouldReturnSuccess()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.PhoneNumbers.GetAll(_customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result as IGetAll<PhoneNumber>);
            Assert.IsNotNull(result.ResponseMetadata);
            Assert.IsTrue(result.Elements.Count >= 1);
            _oldPhoneNumberId = result.Elements[0].PhoneNumberId;
        }

        [TestMethod]
        public async Task Test2002_GetPhoneByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.PhoneNumbers.Get(id: _oldPhoneNumberId, parentId: _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test2003_CreatePhoneNumberShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetPhoneNumberValidRequest();
            // Act
            var result = await _dsCustomerApiClient.PhoneNumbers.Create(request, _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test2004_UpdatePhoneNumberShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetUpdatePhoneNumberValidRequest();
            // Act
            var result = await _dsCustomerApiClient.PhoneNumbers.Update(request, _oldPhoneNumberId, _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test2005_DeletePhoneNumberShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.PhoneNumbers.Delete(_oldPhoneNumberId, _customerId);
            // Assert
            Assert.IsNotNull(result);
        }
        #endregion

        #region Address tests
        [TestMethod]
        public async Task Test3001_GetAllAddressesShouldReturnSuccess()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.Addresses.GetAll(_customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result as IGetAll<Address>);
            Assert.IsNotNull(result.ResponseMetadata);
            Assert.IsTrue(result.Elements.Count >= 1);
            _oldAddressId = result.Elements[0].AddressId;
        }

        [TestMethod]
        public async Task Test3002_GetAddressByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.Addresses.Get(id: _oldAddressId, parentId: _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test3003_CreateAddressShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetAddressValidRequest();
            // Act
            var result = await _dsCustomerApiClient.Addresses.Create(request, _customerId) ;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test3004_UpdateAddressShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetUpdateAddressValidRequest();
            // Act
            var result = await _dsCustomerApiClient.Addresses.Update(request, _oldAddressId, _customerId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsPrimary);
        }

        [TestMethod]
        public async Task Test3005_DeleteAddressShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.Addresses.Delete(_oldAddressId, _customerId);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Test4001_CreateAccountShouldBeSuccessful()
        {
            // Arrange
            var request = TestDataHelper.GetCreateAccountValidRequest(_customerId, _apiSettings.BusinessAccountId);
            _accountExternalId = request.AccountExternalId;

            // Act
            var result = await _dsCustomerApiClient.Accounts.Create(request);
            _accountId = result.AccountId;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.CustomerId == _customerId);
        }
        [TestMethod]
        public async Task Test4002_GetAllAccountsShouldReturnSuccess()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.Accounts.GetAll();
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result as IGetAll<Account>);
            Assert.IsNotNull(result.ResponseMetadata);
            Assert.IsTrue(result.Elements.Count >= 1);
        }

        [TestMethod]
        public async Task Test4003_GetAccountByIdShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.Accounts.Get(_accountId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.AccountId.Equals(_accountId, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.CustomerId == _customerId);
        }


        [TestMethod]
        public async Task Test4004_UpdateAccountShouldBeSuccefull()
        {
            // Arrange
            var updateRequest = TestDataHelper.GetUpdateAccountValidRequest();
            var newAccouuntExternalId = updateRequest.AccountExternalId;
            // Act
            var result = await _dsCustomerApiClient.Accounts.Update(updateRequest, _accountId);
            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.AccountExternalId.Equals(_accountExternalId, StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(result.AccountExternalId.Equals(newAccouuntExternalId, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public async Task Test5001_GetAllPaymentMethodsShouldBeSuccessful()
        {
            // Arrange
            // Act
            var result = await _dsCustomerApiClient.PaymentMethods.GetAll(_customerId);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Test5002_GetAllPaymentsMethodsWithAccountFilterShouldBeSuccessful()
        {
            // Arrange
            var queryParameters = new QueryParameterType[1];
            var accountIdParameter = QueryParameterType.AccountId;
            accountIdParameter.SetValue(_accountId); 
            queryParameters[0] = accountIdParameter;
            // Act
            var result = await _dsCustomerApiClient.PaymentMethods.GetAll(_customerId, queryParameters);
            // Assert
            Assert.IsNotNull(result);
        }
        #endregion
    }
}
