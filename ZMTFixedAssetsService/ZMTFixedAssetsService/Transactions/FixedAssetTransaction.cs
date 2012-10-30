using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IFixedAssetTransactions
    {
        public void AddFixedAsset(EF_ZMTdbEntities.FixedAsset fixedAsset)
        {
            FixedAssetTransactions transaction = new FixedAssetTransactions();
            transaction.AddFixedAsset(fixedAsset);
        }

        public void DeleteFixedAsset(EF_ZMTdbEntities.FixedAsset fixedAsset)
        {
            FixedAssetTransactions transaction = new FixedAssetTransactions();
            transaction.DeleteFixedAsset(fixedAsset);
        }

        public void EditFixedAsset(EF_ZMTdbEntities.FixedAsset fixedAsset)
        {
            FixedAssetTransactions transaction = new FixedAssetTransactions();
            transaction.EditFixedAsset(fixedAsset);
        }
    }
}
