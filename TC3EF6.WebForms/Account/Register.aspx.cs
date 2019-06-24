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
                    Visitor visitor = context.Visitors.Where(v => v.Email == Email.Text).SingleOrDefault();
                    if (visitor == null)
                    {
                        visitor = new Visitor { Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text,
                            Phone = Phone.Text, Visits = 0, DateLastVisit = DateTime.MinValue };
                        context.Visitors.Add(visitor);
                    }
                    else
                    {
                        visitor.FirstName = FirstName.Text;
                        visitor.LastName = LastName.Text;
                        visitor.Phone = Phone.Text;
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
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                AddRegisteredVisitor();
                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}