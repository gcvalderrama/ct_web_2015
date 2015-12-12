using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace NorthwindWin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
        

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest()
        {
            //string username = this.Request.QueryString["username"];
            //if (!string.IsNullOrWhiteSpace(username))
            //{
            //    GenericIdentity identity = new GenericIdentity(username);
            //    GenericPrincipal principal = new GenericPrincipal(identity, new string[] { });
            //    Thread.CurrentPrincipal = principal;
            //    HttpContext.Current.User = principal;
            //}            
        }
        protected void Application_AuthorizeRequest()
        {
            if (this.User.Identity.IsAuthenticated)
            { 
                //
                if(this.User.Identity.Name == "maria" )
                {
                    GenericIdentity identity = new GenericIdentity(this.User.Identity.Name);
                    GenericPrincipal principal = new GenericPrincipal(identity, new string[] {"Managers" });
                    Thread.CurrentPrincipal = principal;
                    HttpContext.Current.User = principal;
                }
            }
        }

       
        protected void Application_BeginRequest()
        {

            
        }

    }

}
