using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IMembershipRoleTransactions
    {
        [OperationContract]
        void AddMembershipRole(MembershipRole role);

        [OperationContract]
        void EditMembershipRole(MembershipRole role);

        [OperationContract]
        void DeleteMembershipRole(MembershipRole role);
    }
}
