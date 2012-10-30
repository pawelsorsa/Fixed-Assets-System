using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : ISubgroupTransactions
    {
        public void AddSubgroup(EF_ZMTdbEntities.Subgroup subgroup)
        {
            SubgroupTransactions transaction = new SubgroupTransactions();
            transaction.AddSubgroup(subgroup);
        }

        public void DeleteSubgroup(EF_ZMTdbEntities.Subgroup subgroup)
        {
            SubgroupTransactions transaction = new SubgroupTransactions();
            transaction.DeleteSubgroup(subgroup);
        }

        public void EditSubgroup(EF_ZMTdbEntities.Subgroup subgroup)
        {
            SubgroupTransactions transaction = new SubgroupTransactions();
            transaction.EditSubgroup(subgroup);
        }
    }
}
