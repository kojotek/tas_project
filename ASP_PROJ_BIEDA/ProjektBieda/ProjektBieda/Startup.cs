using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjektBieda.Startup))]
namespace ProjektBieda
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
