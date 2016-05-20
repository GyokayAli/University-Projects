using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FYProject.Startup))]
namespace FYProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
