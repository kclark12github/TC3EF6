using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using TC3EF6.Data;
using TC3EF6.Domain.Classes;
using TC3EF6.WebForms.Models;

namespace TC3EF6.WebForms.Account
{
    public partial class Manage : BasePage
    {
        static readonly object _object = new object();
        protected string SuccessMessage
        {
            get;
            private set;
        }
        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }
        public bool HasPhoneNumber { get; private set; }
        public bool TwoFactorEnabled { get; private set; }
        public bool TwoFactorBrowserRemembered { get; private set; }
        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());
            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                txtEmail.Text = Visitor.Email;
                txtFirstName.Text = Visitor.FirstName;
                txtLastName.Text = Visitor.LastName;
                txtPhone.Text = Visitor.Phone;
                chkMusic.Checked = Visitor.Music;
                chkAutoStart.Checked = Visitor.AutoStart;
                chkDetached.Checked = Visitor.Detached;
                chkDoLakeGIF.Checked = Visitor.DoLake;
                int target = (int)(Visitor.LakeGIF == null ? 0 : Visitor.LakeGIF);
                ListItem item = null;
                for (int i = 1; i < 20; i++)
                {
                    item = new ListItem($@"&nbsp;<img src=""{Images[i].Path}"" width={Images[i].Width} height={Images[i].Height}/>", i.ToString());
                    if (i == target) item.Selected = true;
                    rblImages.Items.Add(item);
                }
                item = new ListItem("&nbsp;<b>Surprise Me!</b>", "0");
                if (target == 0) item.Selected = true;
                rblImages.Items.Add(item);

                // Determine the sections to render
                if (HasPassword(manager))
                {
                    hlChangePassword.Visible = true;
                }
                else
                {
                    hlCreatePassword.Visible = true;
                    hlChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");
                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }
        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            lock (_object)
            {
                using (var context = new TCContext())
                {
                    //The Visitor read by SiteMaster was managed on a different TCContext instance, so we need to 
                    //reestablish a current image of the record before applying changes...
                    Visitor visitor = context.Visitors.Where(v => v.ID == Visitor.ID).SingleOrDefault();
                    visitor.Music = chkMusic.Checked;
                    visitor.AutoStart = chkAutoStart.Checked;
                    visitor.Detached = chkDetached.Checked;
                    visitor.DoLake = chkDoLakeGIF.Checked;
                    visitor.LakeGIF = int.Parse(rblImages.SelectedItem.Value);
                    context.SaveChanges();
                    Session["Visitor"] = visitor;
                }
            }
            Response.Redirect("~/Default.aspx");
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }
        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }
        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }
    }
}