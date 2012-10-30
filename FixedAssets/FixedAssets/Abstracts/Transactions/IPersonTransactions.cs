using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IPersonTransactions
    {
        [OperationContract]
        void AddPerson(Person person);

        [OperationContract]
        void EditPerson(Person person);

        [OperationContract]
        void DeletePerson(Person person);
    }
}
