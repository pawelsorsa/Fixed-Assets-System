using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssetsTransactions;
using FixedAssets.Abstracts.Transactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IPeripheralDeviceTransactions
    {
        public void AddPeripheralDevice(EF_ZMTdbEntities.PeripheralDevice peripheralDevice)
        {
            PeripheralDeviceTransactions transaction = new PeripheralDeviceTransactions();
            transaction.AddPeripheralDevice(peripheralDevice);
        }

        public void DeletePeripheralDevice(EF_ZMTdbEntities.PeripheralDevice peripheralDevice)
        {
            PeripheralDeviceTransactions transaction = new PeripheralDeviceTransactions();
            transaction.DeletePeripheralDevice(peripheralDevice);
        }

        public void EditPeripheralDevice(EF_ZMTdbEntities.PeripheralDevice peripheralDevice)
        {
            PeripheralDeviceTransactions transaction = new PeripheralDeviceTransactions();
            transaction.EditPeripheralDevice(peripheralDevice);
        }
    }
}
