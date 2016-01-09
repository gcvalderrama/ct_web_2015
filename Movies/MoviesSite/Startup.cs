using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesSite.Startup))]
namespace MoviesSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        
    }
}
