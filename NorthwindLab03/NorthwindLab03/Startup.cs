using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindLab03.Startup))]
namespace NorthwindLab03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
