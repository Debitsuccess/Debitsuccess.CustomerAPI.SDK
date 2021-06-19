using Debitsuccess.CustomerApi.Sdk.Response;
using System;

namespace Debitsuccess.CustomerApi.Sdk.Client
{
    public static class ApiHelpers
    {
        /// <summary>
        /// Get resource name based on the type for generic rest calls
        /// </summary>
        public static string GetResourceName<R>() where R: BaseResponse
        {
            var test = typeof(R).Name;
            return typeof(R).Name switch
            {
                nameof(Account) => "accounts",
                nameof(Accounts) => "accounts",
                nameof(Address) => "addresses",
                nameof(Business) => "businesses",
                nameof(BusinessAccount) => "businessaccounts",
                nameof(Request.CreateCustomer) => "customers",
                nameof(Request.CreateAccount) => "accounts",
                nameof(Customer) => "customers",
                nameof(Customers) => "customers",
                nameof(EmailAddress) => "emailaddresses",
                nameof(ExtendedCustomer) => "customers",
                nameof(OneOffSchedule) => "oneOffSchedules",
                nameof(OneOffSchedules) => "oneOffSchedules",
                nameof(OverdueStatusChange) => "overdueStatusChanges",
                nameof(OverdueStatusChanges) => "overdueStatusChanges",
                nameof(PatchAccount) => "accounts",
                nameof(Payment) => "payments",
                nameof(Payments) => "payments",
                nameof(PaymentMethod) => "paymentMethods",
                nameof(PaymentStatus) => "paymentStatuses",
                nameof(PaymentStatuses) => "paymentStatuses",
                nameof(PhoneNumber) => "phonenumbers",
                nameof(RecurringSchedule) => "recurringSchedules",
                nameof(SuspensionSchedule) => "suspensionSchedules",
                nameof(SuspensionSchedules) => "suspensionSchedules",
                nameof(TermsAndConditions) => "termsAndConditions",
                nameof(UpdateAccount) => "accounts",
                _ => throw new Exception($"No resource found for type {nameof(R)}"),
            };
        }
    }
}
