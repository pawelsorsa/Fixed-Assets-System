using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface ISubgroupTransactions
    {
        [OperationContract]
        void AddSubgroup(Subgroup subgroup);

        [OperationContract]
        void EditSubgroup(Subgroup subgroup);

        [OperationContract]
        void DeleteSubgroup(Subgroup subgroup);
    }
}
