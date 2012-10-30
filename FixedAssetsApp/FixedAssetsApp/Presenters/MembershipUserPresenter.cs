using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.FixedAssetsWebService;
using System.Windows;

namespace FixedAssetsApp.Presenters
{
    public sealed class MembershipUserPresenter
    {
        private MembershipUser currentUser;
        private bool isAuthorized;
        private bool isActive;
        public MembershipUserPresenter()
        {
            isAuthorized = false;
            isActive = true;
        }

        public bool IsActive
        {
            get { return isActive; }
        }

        public bool IsAuthorized
        {
            get { return isAuthorized; }
        }

        public MembershipUser CurrentUser
        {
            get { return currentUser; }
        }
        

        public bool LogOn(string login, string password)
        {
            isAuthorized = false;

            using(MembershipUserServiceClient client = new MembershipUserServiceClient())
            {
                client.Open();
                currentUser = client.GetUserByLogin(login);
                if(currentUser != null)
                {
                    if (currentUser.is_active == false)
                    {
                        isAuthorized = false;
                        isActive = false;
                    }
                    else
                    {
                        if (currentUser.password == password)
                        {
                            currentUser.is_active = true;
                            isAuthorized = true;
                            using (MembershipUserTransactionsClient c = new MembershipUserTransactionsClient())
                            {
                                currentUser.last_login_date = DateTime.Now;
                                c.EditMembershipUser(currentUser);
                            }
                        }
                    }
                }
                else
                {
                    isAuthorized = false;
                }
            }
            return isAuthorized;
        }

        public void LogOut()
        {
            currentUser = null;
            isAuthorized = false;
        }
    }
}
