using System.Collections.Generic;
namespace Debitsuccess.CustomerApi.Sdk.Response
{
    public class DsErrorResponse: BaseResponse
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
    }
}
