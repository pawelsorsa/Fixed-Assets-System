using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IMembershipUserService
    {
        public object[] GetActiveUsers()
        {
            return MembershipUserController.GetActiveUsers();
        }

        public object[] GetAllUsers()
        {
            return MembershipUserController.GetAllUsers();
        }

        public object[] GetNonActiveUsers()
        {
            return MembershipUserController.GetActiveUsers();
        }

        public object[] GetOnlineUsers()
        {
            return MembershipUserController.GetOnlineUsers();
        }

        public EF_ZMTdbEntities.MembershipUser GetUserByEmail(string email)
        {
            return MembershipUserController.GetUserByEmail(email);
        }

        public EF_ZMTdbEntities.MembershipUser GetUserByLogin(string login)
        {
            return MembershipUserController.GetUserByLogin(login);
        }

        public bool IsUserActive(string login)
        {
            return MembershipUserController.IsUserActive(login);
        }

        public bool IsUserInRole(string login, string role)
        {
            return MembershipUserController.IsUserInRole(login, role);
        }

        public bool IsUserOnline(string login)
        {
            return MembershipUserController.IsUserOnline(login);
        }
    }
}
