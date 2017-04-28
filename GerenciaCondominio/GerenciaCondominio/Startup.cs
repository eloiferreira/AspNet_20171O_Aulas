using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GerenciaCondominio.Startup))]
namespace GerenciaCondominio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
