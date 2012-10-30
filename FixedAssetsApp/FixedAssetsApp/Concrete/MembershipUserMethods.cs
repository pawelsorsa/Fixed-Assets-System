using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Concrete
{
    public sealed class MembershipUserMethods
    {
        private ObservableCollection<MembershipUser> users = new ObservableCollection<MembershipUser>();

        public MembershipUserMethods()
        {
            GetAllMembershipUsers();
        }

        public void GetAllMembershipUsers()
        {
             using (FixedAssetsWebService.MembershipUserServiceClient Client = new FixedAssetsWebService.MembershipUserServiceClient())
            {
                Client.Open();
                object[] list = Client.GetAllUsers();
                foreach (MembershipUser user in list)
                {
                    users.Add(user);
                }
            }
        }

        public ObservableCollection<MembershipUser> CreateMembershipUsersList()
        {
            return users;
        }
    }
}
