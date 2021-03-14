using AutoMapper;

using Data;

using Navtech.Models;

namespace ApiService.Helper
{
    public class AutoMapperProfiles
    {
      public  static void AutoMapperProfile()
        {
            Mapper.Initialize(config =>
              {
                  config.CreateMap<CustomerDetailsViewModel, CustomerDetail>().ReverseMap();
                  config.CreateMap<OrderViewModel, Order>().ReverseMap();
                  config.CreateMap<ProductViewModel, Product>().ReverseMap();
            });
        }
    }
}
