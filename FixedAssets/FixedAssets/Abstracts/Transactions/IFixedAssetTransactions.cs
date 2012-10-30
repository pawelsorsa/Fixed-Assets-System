using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IFixedAssetTransactions
    {
        [OperationContract]
        void AddFixedAsset(FixedAsset fixedAsset);

        [OperationContract]
        void EditFixedAsset(FixedAsset fixedAsset);

        [OperationContract]
        void DeleteFixedAsset(FixedAsset fixedAsset);
    }
}
