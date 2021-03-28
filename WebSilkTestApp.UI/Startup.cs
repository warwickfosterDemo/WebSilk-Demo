using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SampleApi.UI.Startup))]
namespace SampleApi.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
