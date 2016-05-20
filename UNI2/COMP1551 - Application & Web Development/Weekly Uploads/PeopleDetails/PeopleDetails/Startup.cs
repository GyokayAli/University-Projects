using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleDetails.Startup))]
namespace PeopleDetails
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
