using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Transactions
{
    [ServiceContract]
    public interface IPeripheralDeviceTransactions
    {
        [OperationContract]
        void AddPeripheralDevice(PeripheralDevice peripheralDevice);

        [OperationContract]
        void EditPeripheralDevice(PeripheralDevice peripheralDevice);

        [OperationContract]
        void DeletePeripheralDevice(PeripheralDevice peripheralDevice);
    }
}
