using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PiProject.web.Startup))]
namespace PiProject.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
