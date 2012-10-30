using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IDeviceTransactions
    {
        [OperationContract]
        void AddDevice(Device device);

        [OperationContract]
        void EditDevice(Device device);

        [OperationContract]
        void DeleteDevice(Device device);
    }
}
