using Debitsuccess.CustomerApi.Sdk.Client.ResourceClients;
using Debitsuccess.CustomerApi.Sdk.Response;
using System;

namespace Debitsuccess.CustomerApi.Sdk.Client
{
    public class CustomerApiClient
    {
        private static DsApiClient _dsApiClient { get => _lazyDsApiClient.Value; }
        private ApiConnectionSettings _apiConnectionSettings;
        private static Lazy<DsApiClient> _lazyDsApiClient;

        private AccountClient _accountClientInstance;
        public AccountClient Accounts { get => _accountClientInstance ??= new AccountClient(_dsApiClient); }

        private GenericGetClient<Business, Businesses> _businessClientInstance;
        public GenericGetClient<Business, Businesses> Businesses { get => _businessClientInstance ??= new GenericGetClient<Business, Businesses>(_dsApiClient); }

        private GenericGetClient<BusinessAccount, BusinessAccounts> _businessAccountClientInstance;
        public GenericGetClient<BusinessAccount, BusinessAccounts> BusinessAccounts { get => _businessAccountClientInstance ??= new GenericGetClient<BusinessAccount, BusinessAccounts>(_dsApiClient); }

        private CustomerClient _customerClientInstance;
        public CustomerClient Customers { get => _customerClientInstance ??= new CustomerClient(_dsApiClient); }
        
        private GenericChildResorceClient<Address, Addresses, Customer> _addressClientInstance;
        public GenericChildResorceClient<Address, Addresses, Customer> Addresses { get => _addressClientInstance ??= new GenericChildResorceClient<Address, Addresses, Customer>(_dsApiClient); }

        private GenericChildResorceClient<EmailAddress, EmailAddresses, Customer> _emailClientInstance;
        public GenericChildResorceClient<EmailAddress, EmailAddresses, Customer> EmailAddresses { get => _emailClientInstance ??= new GenericChildResorceClient<EmailAddress, EmailAddresses, Customer>(_dsApiClient); }

        private GenericChildResorceClient<PhoneNumber, PhoneNumbers, Customer> _phoneClientInstance;
        public GenericChildResorceClient<PhoneNumber, PhoneNumbers, Customer> PhoneNumbers { get => _phoneClientInstance ??= new GenericChildResorceClient<PhoneNumber, PhoneNumbers, Customer>(_dsApiClient); }

        private ScheduleClient<OneOffSchedule, OneOffSchedules, Account> _oneOffSchedulesInstance;
        public ScheduleClient<OneOffSchedule, OneOffSchedules, Account> OneOffSchedules { get => _oneOffSchedulesInstance ??= new ScheduleClient<OneOffSchedule, OneOffSchedules, Account>(_dsApiClient); }

        private ScheduleClient<RecurringSchedule, RecurringSchedules, Account> _recurringScheduleInstance;
        public ScheduleClient<RecurringSchedule, RecurringSchedules, Account> RecurringSchedules { get => _recurringScheduleInstance ??= new ScheduleClient<RecurringSchedule, RecurringSchedules, Account>(_dsApiClient); }

        private SuspensionScheduleClient _suspensionScheduleInstance;
        public SuspensionScheduleClient SuspensionSchedules { get => _suspensionScheduleInstance ??= new SuspensionScheduleClient(_dsApiClient); }

        private GenericGetAllClient<OverdueStatusChange, OverdueStatusChanges> _overdueStatusChangesClientInstance;
        public GenericGetAllClient<OverdueStatusChange, OverdueStatusChanges> OverdueStatusChanges { get => _overdueStatusChangesClientInstance ??= new GenericGetAllClient<OverdueStatusChange, OverdueStatusChanges>(_dsApiClient); }

        private GenericChildResourceGetAllClient<PaymentMethod, PaymentMethods, Customer> _paymentMethodsClientInstance;
        public GenericChildResourceGetAllClient<PaymentMethod, PaymentMethods, Customer> PaymentMethods { get => _paymentMethodsClientInstance ??= new GenericChildResourceGetAllClient<PaymentMethod, PaymentMethods, Customer>(_dsApiClient); }

        private GenericGetClient<Payment, Payments> _paymentsClientInstance;
        public GenericGetClient<Payment, Payments> Payments { get => _paymentsClientInstance ??= new GenericGetClient<Payment, Payments>(_dsApiClient); }

        private GenericChildResourceGetAllClient<PaymentStatus, PaymentStatuses, Business> _paymentStatusClientInstance;
        public GenericChildResourceGetAllClient<PaymentStatus, PaymentStatuses, Business> PaymentStatuses { get => _paymentStatusClientInstance ??= new GenericChildResourceGetAllClient<PaymentStatus, PaymentStatuses, Business>(_dsApiClient); }
        private GenericGetDefaultClient<TermsAndConditions, BusinessAccount> _termsAndConditionsClientInstance;
        public GenericGetDefaultClient<TermsAndConditions, BusinessAccount> TermsAndConditions { get => _termsAndConditionsClientInstance ??= new GenericGetDefaultClient<TermsAndConditions, BusinessAccount>(_dsApiClient); }
        public CustomerApiClient(ApiConnectionSettings apiConnectionSettings)
        {
            this._apiConnectionSettings = apiConnectionSettings;
            _lazyDsApiClient = new Lazy<DsApiClient>(() => new DsApiClient(this._apiConnectionSettings));
        }
    }
}
