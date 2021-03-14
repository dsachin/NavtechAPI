using ApiService.Helper;
using ApiService.Service.Base;

using Navtech.Models;

namespace ApiService.Service
{
    public class BaseService : IBaseService
    {
        public ApiResultModel<dynamic> PrepareReturnResult(string message, string errorCode = null, bool isSuccess = false)
        {
            ApiResultModel<dynamic> apiResult = new ApiResultModel<dynamic>();

            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                {
                    apiResult.Response = ApiConstants.Success;
                }
                else
                {
                    apiResult.ErrorCode = string.IsNullOrEmpty(errorCode)? ApiConstants.CommonErrorCode : errorCode;
                    apiResult.Response = ApiConstants.Error;
                }
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
