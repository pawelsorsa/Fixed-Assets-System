using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IPeripheralDeviceService
    {
        [OperationContract]
        int CountPeripheralDevices();

        [OperationContract]
        object[] GetAllPeripheralDevices();

        [OperationContract]
        PeripheralDevice GetPeripheralDeviceById(int id);

        [OperationContract]
        PeripheralDevice GetPeripheralDeviceByName(string name);

    }
}
