using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VetApp.Startup))]
namespace VetApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
