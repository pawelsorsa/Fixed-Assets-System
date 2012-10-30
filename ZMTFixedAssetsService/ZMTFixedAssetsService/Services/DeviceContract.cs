using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IDeviceService
    {
        public int CountDevices()
        {
            return DeviceController.CountDevices();
        }

        public object[] GetAllDevices()
        {
            return DeviceController.GetAllDevices();
        }

        public EF_ZMTdbEntities.Device GetDeviceById(int id)
        {
            return DeviceController.GetDeviceById(id);
        }

        public EF_ZMTdbEntities.Device GetDeviceByMacAddress(string macAddress)
        {
            return DeviceController.GetDeviceByMacAddress(macAddress);
        }

        public object[] GetDevicesByFixedAssetId(int id)
        {
            return DeviceController.GetDevicesByFixedAssetId(id);
        }

        public object[] GetDevicesByIpAddress(string ipAddress)
        {
            return DeviceController.GetDevicesByIpAddress(ipAddress);
        }

        public object[] GetDevicesByModel(string model)
        {
            return DeviceController.GetDevicesByModel(model);
        }

        public object[] GetDevicesByPheripheralDeviceId(int id)
        {
            return DeviceController.GetDevicesByPheripheralDeviceId(id);
        }

        public object[] GetDevicesByProducer(string producer)
        {
            return DeviceController.GetDevicesByProducer(producer);
        }

        public object[] GetDevicesBySerialNumber(string serialnumber)
        {
            return DeviceController.GetDevicesBySerialNumber(serialnumber);
        }
    }
}
