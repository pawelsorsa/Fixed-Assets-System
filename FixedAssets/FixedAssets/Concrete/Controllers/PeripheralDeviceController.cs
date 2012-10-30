using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class PeripheralDeviceController : IPeripheralDeviceService
    {
        private IPeripheralDeviceRepository repository;
        public PeripheralDeviceController(IPeripheralDeviceRepository repo)
        {
            repository = repo;
        }

        public int CountPeripheralDevices()
        {
            return repository.PeripheralDevices.Count();
        }

        public object [] GetAllPeripheralDevices()
        {
            return repository.PeripheralDevices.ToArray();
        }

        public PeripheralDevice GetPeripheralDeviceById(int id)
        {
            return repository.PeripheralDevices.FirstOrDefault(device => device.id == id);
        }

        public PeripheralDevice GetPeripheralDeviceByName(string name)
        {
            return repository.PeripheralDevices.FirstOrDefault(device => device.name == name);
        }
    }
}
