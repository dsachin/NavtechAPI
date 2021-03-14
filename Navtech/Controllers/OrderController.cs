



using ApiService.Helper;
using ApiService.Service;

using Navtech.Models;

using System;
using System.Web.Http;

namespace Navtech.Controllers
{
    public class OrderController : BaseAPIController
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service) => this.service = service;

        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ApiResultModel<dynamic> CreateOrder([FromBody] OrderProductModel order)
        {
            try
            {
                return service.CreateOrder(order);
            }
            catch (Exception)
            {
                return PrepareReturnResult(ApiConstants.CommonError);
            }
        }

        /// <summary>
        /// Get Orders based on Pagesize, pageIndex
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="isSortedByAscending"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ApiResultModel<dynamic> GetOrders(int pageIndex, int pageSize,bool isSortedByAscending=true)
        {
            try
            {
                return service.GetOrders(pageIndex, pageSize, isSortedByAscending);
            }
            catch (Exception)
            {
                return PrepareReturnResult(ApiConstants.CommonError);
            }
        }
    }
}
