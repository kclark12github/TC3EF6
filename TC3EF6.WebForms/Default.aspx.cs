using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TC3EF6.WebForms
{
    public partial class Default : BasePage
    {
        public string Greeting { get; set; }
        public int HitCount { get; set; }
        public string SessionMessage { get; set; }
        public string ExpectingMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Find a way to make counter look like the webbot used to...
            //var HitCountBot = "webbot i-image=4 bot=HitCounter i-digits=0 preview=&lt;strong&gt;Hit Counter&lt;/strong&gt; u-custom i-resetvalue=0 startspan --" + "><img SRC=\"_vti_bin/fpcount.exe/?Page=Welcome.asp|Image=4\" ALT=\"Hit Counter\"><!--" + "webbot bot=HitCounter endspan i-checksum=7723"
            HitCount = (int)Application["Visitors"];
            Greeting = "Welcome!<br>";
            if (!string.IsNullOrEmpty(((SiteMaster)Page.Master).User))
            {
                if (((SiteMaster)Page.Master).Owner)
                    Greeting = "Welcome Back!<br>Boss Dude...<br>";
                else
                    Greeting = $"Welcome Back!<br>{User}<br>";
            }

            ExpectingMessage = "We've been expecting you...";
            SessionMessage = string.Empty;
            if (((SiteMaster)Page.Master).Owner)
            {
                ExpectingMessage = string.Empty;
                if (Application["ActiveSessions"] == null || (int)Application["ActiveSessions"] == 1)
                    SessionMessage = $"{((SiteMaster)Page.Master).FirstName}, this is the only session connected to your site...";
                else
                    SessionMessage = $"{((SiteMaster)Page.Master).FirstName}, there are {Application["ActiveSessions"]} sessions connected to your site...";
            }
        }
    }
}