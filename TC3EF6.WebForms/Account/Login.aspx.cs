using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using TC3EF6.Data;
using TC3EF6.Domain.Classes;
using TC3EF6.WebForms.Models;

namespace TC3EF6.WebForms.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }
        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // Require the user to have a confirmed email before they can log on.
                var user = manager.FindByName(txtEmail.Text);
                if (user != null)
                {
                    if (!user.EmailConfirmed)
                    {
                        FailureText.Text = "Invalid login attempt. You must have a confirmed email account.";
                        ErrorMessage.Visible = true;
                    }
                    else
                    {
                        // This doen't count login failures towards account lockout
                        // To enable password failures to trigger lockout, change to shouldLockout: true
                        var result = signinManager.PasswordSignIn(txtEmail.Text, txtPassword.Text, chkRememberMe.Checked, shouldLockout: false);
                        switch (result)
                        {
                            case SignInStatus.Success:
                                var returnUrl = Request.QueryString["ReturnUrl"];
                                if (String.IsNullOrEmpty(returnUrl)) returnUrl = "/Default.aspx";
                                IdentityHelper.RedirectToReturnUrl(returnUrl, Response);
                                break;
                            case SignInStatus.LockedOut:
                                Session["Visitor"] = null;
                                Response.Redirect("/Account/Lockout");
                                break;
                            case SignInStatus.RequiresVerification:
                                Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                                Request.QueryString["ReturnUrl"],
                                                                chkRememberMe.Checked),
                                                  true);
                                break;
                            case SignInStatus.Failure:
                            default:
                                Session["Visitor"] = null;
                                FailureText.Text = "Invalid login attempt";
                                ErrorMessage.Visible = true;
                                break;
                        }
                    }
                }
            }
        }
    }
}