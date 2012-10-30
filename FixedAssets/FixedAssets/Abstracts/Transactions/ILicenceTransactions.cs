using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface ILicenceTransactions
    {
        [OperationContract]
        void AddLicence(Licence licence);

        [OperationContract]
        void EditLicence(Licence licence);

        [OperationContract]
        void DeleteLicence(Licence licence);
    }
}
