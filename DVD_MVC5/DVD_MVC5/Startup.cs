using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVD_MVC5.Startup))]
namespace DVD_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
