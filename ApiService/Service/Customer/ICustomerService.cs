using Navtech.Models;

namespace ApiService.Interface
{
    public interface ICustomerService
    {
        /// <summary>
        /// Creates Customer based on customer model.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Api result response as true if created else false</returns>
        ApiResultModel<dynamic> CreateCustomer(CustomerDetailsViewModel customer);

        /// <summary>
        /// Get customer details based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResultModel<dynamic> GetCustomer(int id);

    }
}
