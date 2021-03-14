using ApiService.Helper;
using ApiService.Interface;

using Navtech.Models;

using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Navtech.Controllers
{
    public class CustomerController : BaseAPIController
    {
        private readonly  ICustomerService service;
        public CustomerController(ICustomerService service) => this.service = service;

       /// <summary>
       /// Get Customer based on id
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ApiResultModel<dynamic> Get(int id)
        {
            try
            {
               return service.GetCustomer(id);
            }
            catch (Exception)
            {
                return PrepareReturnResult(ApiConstants.CommonError);
            }          
        }

        /// <summary>
        /// Create Customer based on details
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ApiResultModel<dynamic> CreateCustomer([FromBody] CustomerDetailsViewModel customer)
        {
            try
            {
                return service.CreateCustomer(customer);
            }
            catch (Exception)
            {
                return PrepareReturnResult(ApiConstants.CommonError);
            }
        }
    }
}
