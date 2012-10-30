using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.FixedAssetsWebService;
using System.Collections.ObjectModel;
using FixedAssetsApp.Model;

namespace FixedAssetsApp.Concrete
{
    public class DeviceMethods
    {
        public DeviceMethods()
        {
        }

        public static DeviceModel CreateDeviceModel(Device dev)
        {
            DeviceModel model = new DeviceModel();
            model.comment = dev.comment;
            model.id = dev.id;
            model.id_fixed_asset = dev.id_fixed_asset;
            model.id_peripheral_device = dev.id_peripheral_device;
            model.ip_address = dev.ip_address;
            model.mac_address = dev.mac_address;
            model.model = dev.model;
            model.producer = dev.producer;
            model.serial_number = dev.serial_number;
            model.name_peripheral_device = PeripheralDeviceMethods.GetNameByIdWebServiceMethod(dev.id_peripheral_device);
            return model;
        }

        public static Device CreateDevice(DeviceModel dev)
        {
            Device temp = new Device();
            temp.comment = dev.comment;
            temp.id = dev.id;
            temp.id_fixed_asset = dev.id_fixed_asset;
            temp.id_peripheral_device = dev.id_peripheral_device;
            temp.ip_address = dev.ip_address;
            temp.mac_address = dev.mac_address;
            temp.model = dev.model;
            temp.producer = dev.producer;
            temp.serial_number = dev.serial_number;
            return temp;
        }

        public static ObservableCollection<DeviceModel> CreateDevicesList(object[] table)
        {
            PeripheralDeviceMethods sm = new PeripheralDeviceMethods();
            ObservableCollection<DeviceModel> devicesList = new ObservableCollection<DeviceModel>();
            DeviceModel temp;
            foreach (Device dev in table)
            {
                temp = new DeviceModel();
                temp.comment = dev.comment;
                temp.id = dev.id;
                temp.id_fixed_asset = dev.id_fixed_asset;
                temp.id_peripheral_device = dev.id_peripheral_device;
                temp.ip_address = dev.ip_address;
                temp.mac_address = dev.mac_address;
                temp.model = dev.model;
                temp.producer = dev.producer;
                temp.serial_number = dev.serial_number;
                temp.name_peripheral_device = sm.GetNameById(dev.id_peripheral_device);
                devicesList.Add(temp);
            }
            return devicesList;
        }

        public static object [] GetDevicesByFixedAssetId(int id)
        {
            object[] list;
            using (DeviceServiceClient client = new DeviceServiceClient())
            {
                client.Open();
                list = client.GetDevicesByFixedAssetId(id);
                client.Close();
            }

            return list;
        }
    }
}
