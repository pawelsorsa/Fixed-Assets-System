using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class DeviceController : IDeviceService
    {
        private IDeviceRepository repository;
        public DeviceController(IDeviceRepository repo)
        {
            repository = repo;
        }

        public int CountDevices()
        {
            return repository.Devices.Count();
        }

        public object[] GetAllDevices()
        {
            return repository.Devices.ToArray();
        }

        public Device GetDeviceById(int id)
        {
            return repository.Devices.FirstOrDefault(device => device.id == id);
        }

        public object[] GetDevicesByPheripheralDeviceId(int id)
        {
            return repository.Devices.Where(device => device.id_peripheral_device == id).ToArray();
        }

        public object[] GetDevicesBySerialNumber(string serialnumber)
        {
            return repository.Devices.Where(device => device.serial_number == serialnumber).ToArray();
        }

        public object[] GetDevicesByIpAddress(string ipAddress)
        {
            return repository.Devices.Where(device => device.ip_address == ipAddress).ToArray();
        }

        public Device GetDeviceByMacAddress(string macAddress)
        {
            return repository.Devices.FirstOrDefault(device => device.mac_address == macAddress);
        }

        public object[] GetDevicesByProducer(string producer)
        {
            return repository.Devices.Where(device => device.producer == producer).ToArray();
        }

        public object[] GetDevicesByModel(string model)
        {
            return repository.Devices.Where(device => device.model == model).ToArray();
        }

        public object[] GetDevicesByFixedAssetId(int id)
        {
            return repository.Devices.Where(device => device.id_fixed_asset == id).ToArray();
        }

    }
}
