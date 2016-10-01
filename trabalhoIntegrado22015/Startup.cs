using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trabalhoIntegrado22015.Startup))]
namespace trabalhoIntegrado22015
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
