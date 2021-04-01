using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsIndy.WebMVC.Startup))]
namespace NewsIndy.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
