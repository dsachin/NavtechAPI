using ApiService.Interface;
using ApiService.Service;

using Autofac;
using Autofac.Integration.WebApi;

using System;
using System.Reflection;
using System.Web.Http;

namespace Navtech.Infrastrcture
{
    public class ApiDependencyRegistration
    {
        public static void Initialize(HttpConfiguration config)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(
                RegisterServices(new ContainerBuilder())
            );
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            try
            {
                builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
                builder.RegisterType<CustomerService>().As<ICustomerService>();
                builder.RegisterType<OrderService>().As<IOrderService>();

                //builder.RegisterType<LaunchConfigService>().As<ILaunchConfigService>();
                return builder.Build();
            }
            catch (Exception )
            {
                return null;              
            }
         
        }
    }
}