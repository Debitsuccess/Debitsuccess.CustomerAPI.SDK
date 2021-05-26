using System.Collections.Generic;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class BusinessAccount: BaseResponse
    {
        public string BusinessAccountId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public PenaltyFee PenaltyFee { get; set; }
        public EstablishmentFee EstablishmentFee { get; set; }
        public List<SupportedPaymentMethod> SupportedPaymentMethods { get; set; }
        public Business Business { get; set; }
    }

    public class PenaltyFee
    {
        public decimal Amount { get; set; }
        public string Payer { get; set; }
    }

    public class EstablishmentFee
    {
        public decimal Amount { get; set; }
        public decimal Percent { get; set; }
        public string Payer { get; set; }
    }

    public class SupportedPaymentMethod
    {
        public string PaymentMethodType { get; set; }
    }
}
