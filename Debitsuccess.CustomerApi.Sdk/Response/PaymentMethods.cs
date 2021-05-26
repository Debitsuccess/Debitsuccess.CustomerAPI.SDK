using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PaymentMethods : BaseResponse, IGetAll<PaymentMethod>
    {
        [DataMember(Name = "paymentMethods")]
        public List<PaymentMethod> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
