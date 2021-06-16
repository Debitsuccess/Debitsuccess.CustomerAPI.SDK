using Debitsuccess.CustomerApi.Sdk.Enums;
using Debitsuccess.CustomerApi.Sdk.Request;
using System;
using System.Collections.Generic;

namespace Debitsuccess.CustomerApi.Sdk.Tests.Util
{
    internal static class TestDataHelper
    {
        /// <summary>
        /// Returns valid CreateCustomer request for the provided Business Id
        /// </summary>
        /// <param name="businessId"></param>
        /// <returns><see cref="CreateCustomer"/>> valid request</returns>
        internal static CreateCustomer GetCreateCustomerValidRequest(int businessId)
        {
            return new Request.CreateCustomer()
            {
                BusinessId = businessId,
                CustomerType = "Individual",
                Title = "Mr",
                FirstName = "Shadow",
                MiddleName = "SK",
                LastName = "Knights",
                Gender = GenderType.NonBinary.Value,
                DateOfBirth = DateTime.Now.AddYears(-20),
                Address = new Response.Address()
                {
                    AddressLine1 = "5 The Warehouse Way",
                    AddressLine2 = "Northcote",
                    Suburb = "Northcote",
                    Postcode = "4000",
                    State = "QLD",
                    City = "Brisbane",
                    CountryISOCode = "AUS",
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
                    PhoneName = "home",
                    PhoneType = PhoneType.Home.Value
                }
            };
        }

        internal static UpdateCustomer GetUpdateCustomerValidRequest()
        {
            return new UpdateCustomer()
            {
                Title = "Mr",
                FirstName = "Shadow",
                MiddleName = "SK",
                LastName = "Knights",
                Gender = GenderType.NonBinary.Value,
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
        }

        internal static Response.EmailAddress GetEmailAddressValidRequest()
        {
            return new Response.EmailAddress()
            {
                Email = "shadowknights1@debitsuccess.com",
                EmailName = "primary",
                IsPrimary = true
            };
        }

        internal static Response.EmailAddress GetUpdateEmailAddressValidRequest()
        {
            return new Response.EmailAddress()
            {
                Email = "shadowknights2@debitsuccess.com",
                EmailName = "secondary",
                IsPrimary = false
            };
        }

        internal static Response.PhoneNumber GetPhoneNumberValidRequest()
        {
            return new Response.PhoneNumber()
            {
                CountryCode = "+61",
                AreaCode = "09",
                Number = "123 45678",
                PhoneName = "work",
                PhoneType = PhoneType.Work.Value,
                IsPrimary = true
            };
        }

        internal static Response.PhoneNumber GetUpdatePhoneNumberValidRequest()
        {
            return new Response.PhoneNumber()
            {
                CountryCode = "+61",
                AreaCode = "09",
                Number = "123 45678",
                PhoneName = "mobile",
                PhoneType = PhoneType.Mobile.Value,
                IsPrimary = false
            };
        }

        internal static Response.Address GetAddressValidRequest(CountryType country = null)
        {
            return new Response.Address()
            {
                AddressLine1 = "5 The Warehouse Way",
                AddressLine2 = "Northcote",
                AddressType = AddressType.Legal.Value,
                City = "Sydney",
                CountryISOCode = country is null ? CountryType.Australia.Value : country.Value,
                State = country is null ? "QLD" : "",
                Postcode = "4000",
                IsPrimary = true,
                Suburb = "Some"
            };
        }

        internal static Response.Address GetUpdateAddressValidRequest(CountryType country = null)
        {
            return new Response.Address()
            {
                AddressLine1 = "5 The Warehouse Way",
                AddressLine2 = "Northcote",
                AddressType = AddressType.Physical.Value,
                City = "Sydney",
                CountryISOCode = country is null ? CountryType.Australia.Value : country.Value,
                State = country is null ? "QLD" : "",
                Postcode = "4000",
                IsPrimary = false,
                Suburb = "Some"
            };
        }

        internal static Request.CreateAccount GetCreateAccountValidRequest(int customerId, string businessAccountId)
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
                RecurringScheduleStartDate = DateTime.Today.AddDays(7*10).ToUniversalTime(),
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

        internal static Response.UpdateAccount GetUpdateAccountValidRequest()
        {
            return new Response.UpdateAccount()
            {
                AccountCode = "SDKTest",
                AccountExternalId = "SDKTest_" + DateTime.Now.Ticks,
                TermType = TermType.Months.Value,
                Term = 6,
                FixedTerm = false,
                AccountStartDate = DateTime.Today.AddDays(1).ToUniversalTime(),
                PaymentStopped = false
            };
        }

        internal static Response.OneOffSchedule GetCreateOneOffScheduleValidRequest(int customerId)
        {
            return new Response.OneOffSchedule()
            {
                DueDate = DateTime.Now.AddDays(1),
                Amount = 10.10M,
                ScheduleDescription = "SDK Test installment",
                ExternalScheduleId = $"SDKTST{customerId}"
            };
        }

        internal static Response.RecurringSchedule GetCreateRecurringScheduleValidRequest(int customerId)
        {
            return new Response.RecurringSchedule()
            {
                MinimumEffectiveDate = DateTime.Today.AddDays(7*10),
                Installment = 20.0M,
                Frequency = FrequencyType.Weekly.Value,
                PreviousScheduleEndDate = DateTime.Today.AddDays((7 * 10) - 1),
                ExternalScheduleId = $"SDKTest_new_secondary_{customerId}",
                ScheduleDescription = "SDK Test new secondary",
                DeleteFutureSchedules = true,
                OverrideBillingCycleAlignment = true
            };
        }

        internal static Response.SuspensionSchedule GetCreateSuspensionScheduleValidRequest(int customerId)
        {
            return new Response.SuspensionSchedule()
            {
                MinimumEffectiveDate = DateTime.Today.AddDays(7 * 5),
                SuspensionFee = 20.0M,
                Frequency = FrequencyType.Weekly.Value,
                ExternalScheduleId = $"SDKTest_new_suspension_{customerId}",
                ScheduleDescription = "SDK Test new suspension",
                SuspensionScheduleEndDate = DateTime.Today.AddDays(7 * 7)
            };
        }
    }
}
