using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Concrete;
using System.Collections.ObjectModel;

namespace FixedAssetsApp.Model
{
    public class DeviceModel : ICloneable
    {
        public int id { get; set; }
        public int id_peripheral_device { get; set; }
        public string serial_number { get; set; }
        public string ip_address { get; set; }
        public string mac_address { get; set; }
        public string producer { get; set; }
        public string model { get; set; }
        public string comment { get; set; }
        public int id_fixed_asset { get; set; }
        public string name_peripheral_device { get; set; }
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
