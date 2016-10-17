using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CPT_Server.Startup))]
namespace CPT_Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
