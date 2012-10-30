using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IMembershipUserTransactions
    {
        [OperationContract]
        void AddMembershipUser(MembershipUser membershipUser);

        [OperationContract]
        void EditMembershipUser(MembershipUser membershipUser);

        [OperationContract]
        void DeleteMembershipUser(MembershipUser membershipUser);
    }
}
