using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class MembershipUserController : IMembershipUserService
    {
        private IMembershipUserRepository repository;
        private MembershipRoleController _MembershipRoleController;

        public MembershipUserController(IMembershipUserRepository repo, MembershipRoleController MembershipRoleController)
        {
            repository = repo;
            _MembershipRoleController = MembershipRoleController;
        }

        public bool IsUserInRole(string login, string role)
        {
            throw new NotImplementedException();
            /*
            MembershipRole temp_role = _MembershipRoleController.GetRoleByName(role);
            if(temp_role == null) return false;
            else
            {
                MembershipUser temp_uesr = repository.MembershipUsers.FirstOrDefault(user => (user.login == login
                && user.MembershipRoles.Contains(temp_role)));
                if (temp_uesr != null) return true; else return false; 
            }
             */ 
        }

        public bool IsUserActive(string login)
        {
            MembershipUser temp = repository.MembershipUsers.FirstOrDefault(user => (user.login == login && user.is_active == true));
            if (temp != null) return true; else return false;
        }

        public bool IsUserOnline(string login)
        {
            MembershipUser temp = repository.MembershipUsers.FirstOrDefault(user => (user.login == login && user.is_online == true));
            if (temp.is_online == true) return true; else return false;
        }

        public object[] GetAllUsers()
        {
            return repository.MembershipUsers.ToArray();
        }

        public object[] GetOnlineUsers()
        {
            return repository.MembershipUsers.Where(user => user.is_online == true).ToArray();
        }

        public object[] GetActiveUsers()
        {
            return repository.MembershipUsers.Where(user => user.is_active == true).ToArray();
        }

        public object[] GetNonActiveUsers()
        {
            return repository.MembershipUsers.Where(user => user.is_online == false).ToArray();
        }

        public EF_ZMTdbEntities.MembershipUser GetUserByLogin(string login)
        {
            return repository.MembershipUsers.FirstOrDefault(user => user.login == login);
        }

        public EF_ZMTdbEntities.MembershipUser GetUserByEmail(string email)
        {
            return repository.MembershipUsers.FirstOrDefault(user => user.email == email);
        }
    }
}
