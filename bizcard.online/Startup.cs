using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bizcard.online.Startup))]
namespace bizcard.online
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
