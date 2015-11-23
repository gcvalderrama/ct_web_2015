using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwindZero.Startup))]
namespace NorthwindZero
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
