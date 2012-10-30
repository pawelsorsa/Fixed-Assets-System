using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IMembershipRoleTransactions
    {
        public void AddMembershipRole(EF_ZMTdbEntities.MembershipRole role)
        {
            MembershipRoleTransactions transaction = new MembershipRoleTransactions();
            transaction.AddMembershipRole(role);
        }

        public void DeleteMembershipRole(EF_ZMTdbEntities.MembershipRole role)
        {
            MembershipRoleTransactions transaction = new MembershipRoleTransactions();
            transaction.DeleteMembershipRole(role);
        }

        public void EditMembershipRole(EF_ZMTdbEntities.MembershipRole role)
        {
            MembershipRoleTransactions transaction = new MembershipRoleTransactions();
            transaction.EditMembershipRole(role);
        }
    }
}
