using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHibernetMVC_001.Startup))]
namespace NHibernetMVC_001
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
