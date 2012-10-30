using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IMembershipRoleService
    {
        public object[] GetAllRoles()
        {
            return MembershipRoleController.GetAllRoles();
        }

        public EF_ZMTdbEntities.MembershipRole GetRoleById(int id)
        {
            return MembershipRoleController.GetRoleById(id);
        }

        public EF_ZMTdbEntities.MembershipRole GetRoleByName(string name)
        {
            return MembershipRoleController.GetRoleByName(name);
        }
    }
}
