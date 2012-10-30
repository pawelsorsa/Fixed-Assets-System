using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IKindTransactions
    {
        public void AddKind(EF_ZMTdbEntities.Kind kind)
        {
            KindTransactions transaction = new KindTransactions();
            transaction.AddKind(kind);
        }

        public void DeleteKind(EF_ZMTdbEntities.Kind kind)
        {
            KindTransactions transaction = new KindTransactions();
            transaction.DeleteKind(kind);
        }

        public void EditKind(EF_ZMTdbEntities.Kind kind)
        {
            KindTransactions transaction = new KindTransactions();
            transaction.EditKind(kind);
        }
    }
}
