using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VKart.Startup))]
namespace VKart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
