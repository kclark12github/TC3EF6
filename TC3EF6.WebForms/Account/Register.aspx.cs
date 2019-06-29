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
    public partial class Register : Page
    {
        static readonly object _object = new object();
        protected void AddRegisteredVisitor()
        {
            lock (_object)
            {
                using (var context = new TCContext())
                {   
                    Visitor visitor = context.Visitors.Where(v => v.Email == txtEmail.Text).SingleOrDefault();
                    if (visitor == null)
                    {
                        //Assume this is the first visit...
                        visitor = new Visitor { Email = txtEmail.Text, FirstName = txtFirstName.Text, LastName = txtLastName.Text,
                            Phone = txtPhone.Text, Visits = 1, DateLastVisit = DateTime.Now };
                        context.Visitors.Add(visitor);
                    }
                    else
                    {
                        visitor.FirstName = txtFirstName.Text;
                        visitor.LastName = txtLastName.Text;
                        visitor.Phone = txtPhone.Text;
                    }
                    context.SaveChanges();
                    Session["Visitor"] = visitor;
                }
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = txtEmail.Text, Email = txtEmail.Text };
            IdentityResult result = manager.Create(user, txtPassword.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                if (user.EmailConfirmed)
                {
                    AddRegisteredVisitor();
                    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = "An email has been sent to your account. Please view the email and confirm your account to complete the registration process.";
                }
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}