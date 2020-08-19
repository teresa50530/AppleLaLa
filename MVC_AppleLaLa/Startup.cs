using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_AppleLaLa.Startup))]
namespace MVC_AppleLaLa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
