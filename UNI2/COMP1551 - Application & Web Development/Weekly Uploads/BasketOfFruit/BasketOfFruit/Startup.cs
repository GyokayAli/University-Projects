using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BasketOfFruit.Startup))]
namespace BasketOfFruit
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
