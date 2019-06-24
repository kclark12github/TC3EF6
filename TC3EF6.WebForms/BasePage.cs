using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TC3EF6.WebForms
{
    public class BasePage : Page
    {
        public virtual DateTime PageLastModified
        {
            get
            {
                return new System.IO.FileInfo(Server.MapPath($"{Request.Url.AbsolutePath}.aspx")).LastWriteTime;
            }
        }
    }
}