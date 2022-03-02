using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project113_G3.Startup))]
namespace Project113_G3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
