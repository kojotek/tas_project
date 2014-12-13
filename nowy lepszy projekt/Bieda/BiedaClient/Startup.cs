using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BiedaClient.Startup))]
namespace BiedaClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
