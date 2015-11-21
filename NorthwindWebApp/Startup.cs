using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindWebApp.Startup))]
namespace NorthwindWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
