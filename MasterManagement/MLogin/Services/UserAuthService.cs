using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MLogin.Services
{
    public class UserAuthService
    {
        static UserAuthService()
        {
            AuthService = new UserAuthService();
        }

        internal UserAuthService()
        {
            this.LoginForm = new AppLoginForm();
            this.IsAuth = false;
        }


        public static UserAuthService AuthService { get; private set; }
        internal AppLoginForm LoginForm { get; private set; }
        public bool IsAuth { get; private set; }



        public void BeginCheckAuth()
        {
            LoginForm.ShowDialog();
            this.IsAuth = this.LoginForm.IsLogin;
        }
        public bool UserLogin(string userName, string pwd)
        {
            return false;
        }
        public string EncatryPwd(string pwd)
        {
            return "";
        }
    }
}
