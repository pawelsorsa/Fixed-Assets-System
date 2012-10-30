using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IDeviceTransactions
    {
        public void AddDevice(EF_ZMTdbEntities.Device device)
        {
            DeviceTransactions transaction = new DeviceTransactions();
            transaction.AddDevice(device);
        }

        public void DeleteDevice(EF_ZMTdbEntities.Device device)
        {
            DeviceTransactions transaction = new DeviceTransactions();
            transaction.DeleteDevice(device);
        }

        public void EditDevice(EF_ZMTdbEntities.Device device)
        {
            DeviceTransactions transaction = new DeviceTransactions();
            transaction.EditDevice(device);
        }
    }
}
