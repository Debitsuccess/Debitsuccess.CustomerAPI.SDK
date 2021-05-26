using Debitsuccess.CustomerApi.Sdk.Client;
using Debitsuccess.CustomerApi.Sdk.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.TestConsole
{
    static class Program
    {
        async static Task Main(string[] args)
        {
            var apiSettings = new ApiConnectionSettings()
            {
                IdentityUrl = "https://oc-test.debitsuccess.com/identity/",
                CustomerApiUrl = "https://oc-test.debitsuccess.com/customerservices/v1.0/",
                ClientId = "YOUR_CLIENT_ID",
                ClientSecret = "YOUR_CLIENT_SECRET"
            };
            var customerApiClient = new CustomerApiClient(apiSettings);
            var customer = await customerApiClient.Customers.Create(GetCreateCustomerRequest());
            var account = await customerApiClient.Accounts.Create(GetCreateAccountValidRequest(customer.CustomerId, "BUSINESSACCOUNTID"));
            Console.WriteLine($"Created an account with id: {account.AccountId}");
            Console.ReadLine();
        }

        private static Request.CreateCustomer GetCreateCustomerRequest()
        {
            var request = new Request.CreateCustomer()
            {
                BusinessId = 7211,
                CustomerType = "Individual",
                Title = "Mr",
                FirstName = "Shadow",
                MiddleName = "SK",
                LastName = "Knights",
                Gender = GenderType.Male.Value,
                DateOfBirth = DateTime.Now.AddYears(-20),
                Address = new Response.Address()
                {
                    AddressLine1 = "5 The Warehouse Way",
                    AddressLine2 = "Northcote",
                    Suburb = "Northcote",
                    Postcode = "4000",
                    State = "QLD",
                    City = "Brisbane",
                    CountryISOCode = CountryType.Australia.Value,
                    AddressType = AddressType.Postal.Value
                },
                EmailAddress = new Response.EmailAddress()
                {
                    Email = "shadowknights@debitsuccess.com",
                    EmailName = "work"
                },
                PhoneNumber = new Response.PhoneNumber()
                {
                    CountryCode = "+61",
                    AreaCode = "09",
                    Number = "264 45654",
                    PhoneName = "work",
                    PhoneType = PhoneType.Work.Value
                }
            };

            return request;
        }

        private static Request.CreateAccount GetCreateAccountValidRequest(int customerId, string businessAccountId)
        {
            var recurringSchedules = new List<Response.CreateAccountRecurringSchedule>();
            recurringSchedules.Add(new Response.CreateAccountRecurringSchedule()
            {
                RecurringScheduleStartDate = DateTime.Today.AddDays(7).ToUniversalTime(),
                Installment = 12.5M,
                Frequency = FrequencyType.Weekly.Value,
                NumberOfPayments = 9,
                ExternalScheduleId = $"SDKTest_initial_{customerId}",
                ScheduleDescription = "SDK Test"
            });
            recurringSchedules.Add(new Response.CreateAccountRecurringSchedule()
            {
                RecurringScheduleStartDate = DateTime.Today.AddDays(7 * 10).ToUniversalTime(),
                Installment = 20.0M,
                Frequency = FrequencyType.Weekly.Value,
                NumberOfPayments = null,
                ExternalScheduleId = $"SDKTest_secondary_{customerId}",
                ScheduleDescription = "SDK Test secondary"
            });
            return new Request.CreateAccount()
            {
                CustomerId = customerId,
                BusinessAccountId = businessAccountId,
                AccountExternalId = "SDKTest_" + DateTime.Now.Ticks,
                AccountCode = "SDKTest",
                TermType = TermType.Months.Value,
                Term = 6,
                AccountNotes = $"Created at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}",
                FixedTerm = false,
                WaiveEstFee = false,
                AlignEstFeeWithSchedule = true,
                AccountStartDate = DateTime.Today.AddDays(1).ToUniversalTime(),
                ContractAmount = null,
                RecurringSchedules = recurringSchedules
            };
        }
    }
}
