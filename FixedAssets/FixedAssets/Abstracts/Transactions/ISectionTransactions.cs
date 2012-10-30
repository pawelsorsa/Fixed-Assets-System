using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface ISectionTransactions
    {
        [OperationContract]
        void AddSection(Section section);

        [OperationContract]
        void EditSection(Section section);

        [OperationContract]
        void DeleteSection(Section section);
    }
}
