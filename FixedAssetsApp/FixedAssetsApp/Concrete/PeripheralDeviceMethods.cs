using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Concrete
{
    public class PeripheralDeviceMethods
    {
        private ObservableCollection<PeripheralDevice> devices = new ObservableCollection<PeripheralDevice>();
        public PeripheralDeviceMethods()
        {
            GetAllPeripheralDevices();
        }

        public void GetAllPeripheralDevices()
        {
            using (FixedAssetsWebService.PeripheralDeviceServiceClient Client = new FixedAssetsWebService.PeripheralDeviceServiceClient())
            {
                Client.Open();
                object[] list = Client.GetAllPeripheralDevices();
                foreach (PeripheralDevice dev in list)
                {
                    devices.Add(dev);
                }
            }
        }

        public ObservableCollection<PeripheralDevice> CreatePeripheralDevicesList()
        {
            return devices;
        }

        public string GetNameById(int id)
        {
            PeripheralDevice device = devices.FirstOrDefault(x => x.id == id);
            if (device != null)
            {
                return device.name;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetNameByIdWebServiceMethod(int id)
        {
            string name = string.Empty;
            using (FixedAssetsWebService.PeripheralDeviceServiceClient Client = new FixedAssetsWebService.PeripheralDeviceServiceClient())
            {
                Client.Open();
                PeripheralDevice dev = Client.GetPeripheralDeviceById(id);
                if (dev!=null)
                {
                    return dev.name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static int GetIdByNameWebServiceMethod(string name)
        {
            
            using (FixedAssetsWebService.PeripheralDeviceServiceClient Client = new FixedAssetsWebService.PeripheralDeviceServiceClient())
            {
                Client.Open();
                PeripheralDevice dev = Client.GetPeripheralDeviceByName(name);
                if (dev != null)
                {
                    return dev.id;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string[] GetAllPeripheralDevAsStringArray()
        {
            string[] array = devices.Select(x => x.name).Distinct().ToArray<string>();
            return array;
        }
    }
}
