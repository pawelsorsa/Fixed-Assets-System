using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class MembershipRoleController : IMembershipRoleService
    {
        private IMembershipRoleRepository repository;

        public MembershipRoleController(IMembershipRoleRepository repo)
        {
            repository = repo;
        }

        public object[] GetAllRoles()
        {
            return repository.MembershipRoles.ToArray();
        }

        public MembershipRole GetRoleById(int id)
        {
            return repository.MembershipRoles.FirstOrDefault(role => role.id == id);
        }

        public MembershipRole GetRoleByName(string name)
        {
            return repository.MembershipRoles.FirstOrDefault(role => role.name == name);
        }
    }
}
