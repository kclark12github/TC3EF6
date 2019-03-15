using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC3EF6.Data;
using TC3EF6.Domain;

namespace TC3EF6.Data.Login
{
    public class User : DataEntityBase
    {
        public User()
        {
            try
            {
                Domain = Environment.UserDomainName;
                LoginID = Environment.UserName;
            }
            catch (Exception) { }
        }
        #region "Properties"
        private string mDomain = string.Empty;
        private string mLoginID = string.Empty;
        private string mPassword = string.Empty;
        private bool mIsDomainVisible = false;
        private bool mRememberMe = false;
        public string Domain
        {
            get => mDomain;
            set { SetProperty(ref mDomain, value); }
        }
        public string LoginID
        {
            get => mLoginID;
            set { SetProperty(ref mLoginID, value); }
        }
        public string Password
        {
            get => mPassword;
            set { SetProperty(ref mPassword, value); }
        }
        public bool IsDomainVisible
        {
            get => mIsDomainVisible;
            set { SetProperty(ref mIsDomainVisible, value); }
        }
        public bool RememberMe
        {
            get => mRememberMe;
            set { SetProperty(ref mRememberMe, value); }
        }
        #endregion
        #region "Methods"
        public void Clear()
        {
            base.ClearValidationMessages();
            Domain = string.Empty;
            LoginID = string.Empty;
            Password = string.Empty;
            IsDomainVisible = false;
            RememberMe = false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"LoginID: {mLoginID}");
            sb.AppendLine($"Password: {mPassword}");
            sb.AppendLine($"Domain: {mDomain}");
            return sb.ToString();
        }
        public override bool Validate()
        {
            base.ClearValidationMessages();
            if (String.IsNullOrEmpty(mLoginID))
                base.AddValidationRuleMessage("LoginID", "Login ID must be provided!");
            if (String.IsNullOrEmpty(mPassword))
                base.AddValidationRuleMessage("Password", "Password must be provided!");
            if (mIsDomainVisible && String.IsNullOrEmpty(mDomain))
                base.AddValidationRuleMessage("Domain", "Domain must be provided!");
            return (base.ValidationRuleMessages.Count == 0);
        }
        #endregion
    }
}
