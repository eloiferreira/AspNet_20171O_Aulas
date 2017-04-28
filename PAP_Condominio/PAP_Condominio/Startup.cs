using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PAP_Condominio.Startup))]
namespace PAP_Condominio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
