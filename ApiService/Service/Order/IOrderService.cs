

using Navtech.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiService.Service
{
    public interface IOrderService
    {
        /// <summary>
        /// Creates Customer based on customer model.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Api result response as true if created else false</returns>
        ApiResultModel<dynamic> CreateOrder(OrderProductModel order);

        /// <summary>
        /// Get customer details based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResultModel<dynamic> GetOrders(int pageIndex, int pageSize, bool isSortedByAscending = true);
    }
}
