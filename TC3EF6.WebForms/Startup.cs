using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TC3EF6.WebForms.Startup))]
namespace TC3EF6.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
