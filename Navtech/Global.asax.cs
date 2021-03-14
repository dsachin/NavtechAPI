using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

using ApiService.Helper;

using Navtech.Infrastrcture;

namespace Navtech
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperProfiles.AutoMapperProfile();
            ApiDependencyRegistration.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
