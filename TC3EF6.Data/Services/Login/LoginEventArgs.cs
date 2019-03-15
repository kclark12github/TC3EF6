using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC3EF6.Data.Login
{
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs()
        {
            LoginObject = null;
        }
        public LoginEventArgs(User login)
        {
            LoginObject = login;
        }
        public User LoginObject { get; set; }
    }
}
