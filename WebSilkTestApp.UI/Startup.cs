using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSilkTestApp.UI.Startup))]
namespace WebSilkTestApp.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
