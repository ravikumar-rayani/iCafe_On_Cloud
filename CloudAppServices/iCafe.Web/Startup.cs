using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckConfig.Startup))]
namespace CheckConfig
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
