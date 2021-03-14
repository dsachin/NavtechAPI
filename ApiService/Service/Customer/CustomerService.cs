using ApiService.Helper;
using ApiService.Interface;

using AutoMapper;

using Data;

using Navtech.Models;

using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;

namespace ApiService.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        private OrderManagementEntities db = new OrderManagementEntities();

        public ApiResultModel<dynamic> CreateCustomer(CustomerDetailsViewModel customer)
        {
            ApiResultModel<dynamic> apiResult;
            try
            {
                customer.CreatedDate = DateTime.Now;
                customer.ModifiedDate = DateTime.Now;
                CustomerDetail customerDetails = Mapper.Map<CustomerDetail>(customer);
                db.CustomerDetails.Add(customerDetails);
                db.SaveChanges();
                apiResult = PrepareReturnResult(ApiConstants.CustomerCreatedSuccessfully, isSuccess: true);
            }
            catch (DbEntityValidationException)
            {
                apiResult = PrepareReturnResult(ApiConstants.InvalidInputs);
            }
            catch (Exception ex)
            {
                if (IsDuplicateEmailIdException(ex))
                {
                    apiResult = PrepareReturnResult(ApiConstants.DuplicateEmail);
                }
                else
                {
                    throw ex;
                }
            }
            return apiResult;
        }


        public ApiResultModel<dynamic> GetCustomer(int id)
        {
            ApiResultModel<dynamic> apiResult = new ApiResultModel<dynamic>();
            try
            {
                CustomerDetail customer = db.CustomerDetails.Where(x => x.Id == id).FirstOrDefault();
                if (customer != null)
                {
                    CustomerDetailsViewModel customerDetails = Mapper.Map<CustomerDetailsViewModel>(customer);
                    apiResult = PrepareReturnResult(string.Empty);
                    apiResult.Data = customerDetails;
                }
                else
                {
                    apiResult = PrepareReturnResult(ApiConstants.NoCustomeFound);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return apiResult;
        }

        private bool IsDuplicateEmailIdException(Exception ex)
        {
            if (ex is DbUpdateException dbUpdateEx && dbUpdateEx.InnerException != null
                        && dbUpdateEx.InnerException.InnerException != null)
            {
                if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                {
                    switch (sqlException.Number)
                    {
                        case 2627: // Check  for Unique constraint error
                            return true;
                        default:
                            return false;
                    }
                }
            }
            return false; ;
        }
    }
}
