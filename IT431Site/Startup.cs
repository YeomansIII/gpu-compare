using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT431Site.Startup))]
namespace IT431Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
