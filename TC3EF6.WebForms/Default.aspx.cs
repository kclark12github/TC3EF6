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
        const int defaultWelcomeImage = 1;      //Michael Whelan's Filed Teeth image...
        public string Greeting { get; set; }
        public int HitCount { get; set; }
        public string SessionMessage { get; set; }
        public string ExpectingMessage { get; set; }
        public int GIFHeight { get; private set; }
        public string GIFPath { get; private set; }
        public int GIFWidth { get; private set; }

        private int DetermineImageIndex()
        {
            if (Visitor == null) return defaultWelcomeImage;
            int iImage = (int)Visitor.LakeGIF;
            if (iImage == 0) { 
                Random random = new Random();
                iImage = random.Next(1, Images.Count - 1);
            }
            return iImage;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Find a way to make counter look like the webbot used to... or not...
            //var HitCountBot = "webbot i-image=4 bot=HitCounter i-digits=0 preview=&lt;strong&gt;Hit Counter&lt;/strong&gt; u-custom i-resetvalue=0 startspan --" + "><img SRC=\"_vti_bin/fpcount.exe/?Page=Welcome.asp|Image=4\" ALT=\"Hit Counter\"><!--" + "webbot bot=HitCounter endspan i-checksum=7723"
            HitCount = (int)Application["Visitors"];
            Greeting = "Welcome!";
            if (!string.IsNullOrEmpty(Context.User.Identity.Name))
            {
                if (Owner)
                    Greeting = "Welcome Back<br>Boss Dude...!";
                else
                    Greeting = $"Welcome Back<br>{Visitor.FirstName}!";
            }
            Greeting += "<br/>";

            ImageData iData = Images[DetermineImageIndex()];
            GIFHeight = iData.Height;
            GIFPath = iData.Path;
            GIFWidth = iData.Width;

            ExpectingMessage = "We've been expecting you...";
            SessionMessage = string.Empty;
            if (Owner)
            {
                ExpectingMessage = string.Empty;
                if (Application["ActiveSessions"] == null || (int)Application["ActiveSessions"] == 1)
                    SessionMessage = $"{Visitor.FirstName}, this is the only session connected to your site...";
                else
                    SessionMessage = $"{Visitor.FirstName}, there are {Application["ActiveSessions"]} sessions connected to your site...";
            }
        }
    }
}