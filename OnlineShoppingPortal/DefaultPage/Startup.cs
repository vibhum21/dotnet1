using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DefaultPage.Startup))]
namespace DefaultPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
