using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Web
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public partial class Startup
    {
        //Katana is Microsoft's implementation of the Open Web Interface for .NET (OWIN)
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth is located in the other portion of this partial class found in
            //App_Start/Startup.Auth.cs. It configures boiler-plate aspects of the Katana
            //pipeline such as:
            //  - app.SetDefaultSignInAsAuthenticationType()
            //  - app.UseCookieAuthentication()
            //  - app.UseOpenIdConnectAuthentication()
            ConfigureAuth(app);
        }
    }
}
