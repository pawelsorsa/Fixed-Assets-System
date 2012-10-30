using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.Model;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Presenters
{
    public class DeviceEditPresenter : PresenterBase<DeviceEditView>
    {
        public DeviceEditPresenter(DeviceEditView deviceEditView, DeviceModel dev)
        : base(deviceEditView) 
        {
            PeripheralDeviceMethods peripheralMethods = new PeripheralDeviceMethods();
            deviceEditView.DataContext = dev;
            deviceEditView.ComboBox_Devies.ItemsSource = peripheralMethods.GetAllPeripheralDevAsStringArray();
        }
    }
}


