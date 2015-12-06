using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMvcEfcf.Startup))]
namespace WebMvcEfcf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
