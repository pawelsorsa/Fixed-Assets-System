using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IDeviceService
    {
        [OperationContract]
        int CountDevices();

        [OperationContract]
        object[] GetAllDevices();

        [OperationContract]
        Device GetDeviceById(int id);

        [OperationContract]
        object[] GetDevicesByPheripheralDeviceId(int id);

        [OperationContract]
        object[] GetDevicesBySerialNumber(string serialnumber);

        [OperationContract]
        object[] GetDevicesByIpAddress(string ipAddress);

        [OperationContract]
        Device GetDeviceByMacAddress(string macAddress);

        [OperationContract]
        object[] GetDevicesByProducer(string producer);

        [OperationContract]
        object[] GetDevicesByModel(string model);

        [OperationContract]
        object[] GetDevicesByFixedAssetId(int id);
    }
}
