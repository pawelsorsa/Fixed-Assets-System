using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IPeripheralDeviceService
    {
        public int CountPeripheralDevices()
        {
            return PeripheralDeviceController.CountPeripheralDevices();
        }

        public object[] GetAllPeripheralDevices()
        {
            return PeripheralDeviceController.GetAllPeripheralDevices();
        }

        public EF_ZMTdbEntities.PeripheralDevice GetPeripheralDeviceById(int id)
        {
            return PeripheralDeviceController.GetPeripheralDeviceById(id);
        }

        public EF_ZMTdbEntities.PeripheralDevice GetPeripheralDeviceByName(string name)
        {
            return PeripheralDeviceController.GetPeripheralDeviceByName(name);
        }
    }
}
