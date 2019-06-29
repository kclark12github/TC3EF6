using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using TC3EF6.Data;
using TC3EF6.Domain.Classes;

namespace TC3EF6.WebForms
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        static readonly object _object = new object();

        public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public bool Owner { get; set; }
        private DateTime? PageLastModified
        {
            get
            {
                string path = Server.MapPath(Request.Url.AbsolutePath);
                if (!File.Exists(path)) path = $"{path}.aspx";
                if (!File.Exists(path)) return null;
                return new System.IO.FileInfo(path).LastWriteTime;
            }
        }
        //public string User { get; set; }

        protected void LogMessage(string Message)
        {
            using (var context = new TCContext())
            {
                context.LogMessage((string)Application["AppName"], Message);
            }
        }
        protected static void LogMessage(string Milestone, string Message)
        {
            using (var context = new TCContext())
            {
                context.LogMessage(Milestone, Message);
            }
        }
        protected virtual string GetPageLastModified()
        {
            DateTime? plm = this.PageLastModified;
            if (plm == null) return $"Cannot determine Last Modified Date for {Server.MapPath(Request.Url.AbsolutePath)}";
            return $"{plm:dddd MMMM d, yyyy @ hh:mm tt}";
        }
        private Visitor GetVisitor(string Email)
        {
            lock (_object)
            {
                using (var context = new TCContext())
                {   //The fact that the visitor is registered means there should be a Visitor record...
                    Visitor visitor = context.Visitors.Where(v => v.Email == Email).SingleOrDefault();
                    visitor.Visits += 1; visitor.DateLastVisit = DateTime.Now;
                    Session["Visitor"] = visitor;

                    string appName = (string)Application["AppName"];
                    AppState appState = context.AppStates.Where(a => a.AppName == appName).SingleOrDefault();
                    appState.LastVisitor = Email; appState.DateLastVisit = DateTime.Now;
                    context.SaveChanges();
                    return visitor;
                }
            }
        }
        private void InitUserStuff()
        {
            Visitor visitor = (Visitor)Session["Visitor"];
            FirstName = string.Empty;
            if (visitor == null)
            {
                //Note that we're depending on the logic that adds a Visitor record when the user registers...
                if (!string.IsNullOrEmpty(Context.User.Identity.Name))
                {
                    visitor = GetVisitor(Context.User.Identity.Name);
                }
                else
                {
                    //LastName = string.Empty;
                    //Owner = false;
                    //User = string.Empty;
                    return;
                }
            }
            FirstName = visitor.FirstName;
            //LastName = visitor.LastName;
            //Owner = (User == (string)Application["Owner"]);
            //User = visitor.Email;
            Session["Visitor"] = visitor;
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }
        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
            InitUserStuff();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}