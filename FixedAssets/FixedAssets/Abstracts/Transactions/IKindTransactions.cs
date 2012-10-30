using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IKindTransactions
    {
        [OperationContract]
        void AddKind(Kind kind);

        [OperationContract]
        void EditKind(Kind kind);

        [OperationContract]
        void DeleteKind(Kind kind);
    }
}
