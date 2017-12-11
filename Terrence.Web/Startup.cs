using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Terrence.Web.Startup))]
namespace Terrence.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
