using Entidades.EFCF;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMvcEfcf.App_Start;
using WebMvcEfcf.ModelBinders;
using WebMvcEfcf.ValueProviders;

namespace WebMvcEfcf
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            MapperConfig.Configuration();

            //Para que el custom value provider sea usado primero.
            ValueProviderFactories.Factories.Insert(0, 
                new ProductValueProviderFactory());

            //Para que el custom value provider sea usado en caso ninguno de los default hayan podido resolverlo.
            //System.Web.Mvc.ValueProviderFactories.Factories.Add(new ProductValueProviderFactory());

            //Para usar el custom model binder
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Product), new ProductBinder());
        }
    }
}
