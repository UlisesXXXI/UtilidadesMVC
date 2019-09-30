using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Utilidades.Startup))]
namespace Utilidades
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
