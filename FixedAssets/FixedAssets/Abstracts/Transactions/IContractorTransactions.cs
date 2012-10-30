using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IContractorTransactions
    {
        [OperationContract]
        void AddContractor(Contractor contractor);

        [OperationContract]
        void EditContractor(Contractor contractor);

        [OperationContract]
        void DeleteContractor(Contractor contractor);
    }
}
