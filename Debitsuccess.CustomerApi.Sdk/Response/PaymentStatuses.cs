using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class PaymentStatuses : BaseResponse, IGetAll<PaymentStatus>
    {
        [DataMember(Name = "paymentStatuses")]
        public List<PaymentStatus> Elements { get; set; }
        public ResponseMetadata ResponseMetadata { get; set; }
    }
}
