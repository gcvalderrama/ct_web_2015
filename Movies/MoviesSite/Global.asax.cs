using MoviesSite.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MoviesSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            
        }
        public override void Init()
        {
            base.Init();            
        }
        protected void Application_Start()
        {            
            MapperConfig.Config(); 
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);     
        }
    }  
}
