using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NortwindForms.Startup))]
namespace NortwindForms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
