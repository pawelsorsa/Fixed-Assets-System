using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;


namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IMembershipUserTransactions
    {
        public void AddMembershipUser(EF_ZMTdbEntities.MembershipUser membershipUser)
        {
            MembershipUserTransactions transaction = new MembershipUserTransactions();
            transaction.AddMembershipUser(membershipUser);
        }

        public void DeleteMembershipUser(EF_ZMTdbEntities.MembershipUser membershipUser)
        {
            MembershipUserTransactions transaction = new MembershipUserTransactions();
            transaction.DeleteMembershipUser(membershipUser);
        }

        public void EditMembershipUser(EF_ZMTdbEntities.MembershipUser membershipUser)
        {
            MembershipUserTransactions transaction = new MembershipUserTransactions();
            transaction.EditMembershipUser(membershipUser);
        }
    }
}
