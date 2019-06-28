using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TC3EF6.WebForms.Admin
{
    public partial class Admin : BasePage
    {
        public string Greeting { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((SiteMaster)Page.Master).User))
            {
                if (((SiteMaster)Page.Master).Owner)
                    Greeting = "Hey <b>Boss</b>, ";
                else
                    Greeting = $"Hey <b>{((SiteMaster)Page.Master).FirstName}</b>, ";
            }
            else
                Greeting = "Hey, ";
            Greeting += "Thanks for Stopping By...!";
        }
    }
}