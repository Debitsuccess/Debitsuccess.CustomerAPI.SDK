using Debitsuccess.CustomerApi.Sdk.Client;
using Debitsuccess.CustomerApi.Sdk.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Debitsuccess.CustomerApi.Sdk.Tests
{
    [TestClass]
    public class ApiHelpersTests
    {
        [DataTestMethod]
        [DataRow(typeof(Account), "accounts")]
        [DataRow(typeof(Accounts), "accounts")]
        [DataRow(typeof(Address), "addresses")]
        [DataRow(typeof(Business), "businesses")]
        [DataRow(typeof(BusinessAccount), "businessaccounts")]
        [DataRow(typeof(CreateCustomer), "customers")]
        [DataRow(typeof(CreateAccount), "accounts")]
        [DataRow(typeof(Customer), "customers")]
        [DataRow(typeof(EmailAddress), "emailaddresses")]
        [DataRow(typeof(ExtendedCustomer), "customers")]
        [DataRow(typeof(OneOffSchedule), "oneOffSchedules")]
        [DataRow(typeof(OneOffSchedules), "oneOffSchedules")]
        [DataRow(typeof(PatchAccount), "accounts")]
        [DataRow(typeof(Payments), "payments")]
        [DataRow(typeof(PaymentMethod), "paymentMethods")]
        [DataRow(typeof(PaymentStatuses), "paymentStatuses")]
        [DataRow(typeof(PaymentToken), "paymentTokens")]
        [DataRow(typeof(PhoneNumber), "phonenumbers")]
        [DataRow(typeof(RecurringSchedule), "recurringSchedules")]
        [DataRow(typeof(TermsAndConditions), "termsAndConditions")]
        [DataRow(typeof(UpdateAccount), "accounts")]        
        public void GetResourceNameShouldReturnRightName(Type type, string expectedResourceName)
        {
            // Arrange
            // Act
            var result = typeof(ApiHelpers).GetMethod("GetResourceName").MakeGenericMethod(type).Invoke(null, null);
            // Assert
            Assert.AreEqual(expectedResourceName, result as string);
        }
    }
}
