
using ApiService.Helper;

using Navtech.Models;

using System.Web.Http;

namespace Navtech.Controllers
{
    public class BaseAPIController : ApiController
    {
        public ApiResultModel<dynamic> PrepareReturnResult(string message, string errorCode = null)
        {
            ApiResultModel<dynamic> apiResult = new ApiResultModel<dynamic>();

            if (!string.IsNullOrEmpty(message))
            {
                apiResult.ErrorCode = string.IsNullOrEmpty(errorCode) ? ApiConstants.CommonErrorCode : errorCode;
                apiResult.Response = ApiConstants.Error;
                apiResult.Message = message;
            }
            else
            {
                apiResult.Response = ApiConstants.Success;
            }
            return apiResult;
        }
    }
}
