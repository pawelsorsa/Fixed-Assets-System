using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FixedAssetsApp.Presenters;
using System.Threading;
using FixedAssetsApp.Model;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for DeviceView.xaml
    /// </summary>
    public partial class DeviceView : UserControl
    {
        private delegate void GetDataDelegate();
        private DevicePresenter devicePresenter;
        public DeviceView()
        {
            InitializeComponent();
            devicePresenter = new DevicePresenter(this);
            DataContext = devicePresenter;
            PeripheralDeviceMethods per = new PeripheralDeviceMethods();
            ComboBox_Devies.ItemsSource = per.GetAllPeripheralDevAsStringArray();
            ComboBox_Devies.SelectedIndex = 0;
        }

        private void Execute(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void dataGridDevices_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        DevicePresenter devicePresenter = (DevicePresenter)this.DataContext;
                        var device = (DeviceModel)this.dataGridDevices.SelectedItem;
                        if (device != null)
                        {
                            devicePresenter.DeleteDevice((DeviceModel)device);
                            e.Handled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DevicePresenter devicePresenter = (DevicePresenter)this.DataContext;

                DeviceModel device = (DeviceModel)((DeviceModel)devicePresenter.View.dataGridDevices.SelectedItem).Clone();
                DeviceEditPresenter deviceEditPresenter = new DeviceEditPresenter(new DeviceEditView(), device);
                deviceEditPresenter.View.Label_AddOrEditDevice.Content = "Edytowanie urządzenia";
                deviceEditPresenter.View.ComboBox_Devies.SelectedValue = device.name_peripheral_device;
                if (deviceEditPresenter.View.ShowDialog() == true)
                {
                    devicePresenter.SaveDevice(device, true);
                    DeviceModel temp = (DeviceModel)devicePresenter.View.dataGridDevices.SelectedItem;
                    ChangeCurrentRow(devicePresenter, deviceEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_GetAllDevices_Click(object sender, RoutedEventArgs e)
        {
            Execute(devicePresenter.GetAllDevices);
        }

        private void btn_AddDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DeviceEditPresenter deviceEditPresenter = new DeviceEditPresenter(new DeviceEditView(), new DeviceModel());
                deviceEditPresenter.View.Label_AddOrEditDevice.Content = "Tworzenie urządzenia";
                deviceEditPresenter.View.ComboBox_Devies.SelectedIndex = 0;
                DeviceModel dev = (DeviceModel)deviceEditPresenter.View.DataContext;

                if (deviceEditPresenter.View.ShowDialog() == true)
                {
                    if (dev != null)
                    {
                        devicePresenter.SaveDevice(dev, false);
                        DeviceModel temp = (DeviceModel)devicePresenter.View.dataGridDevices.SelectedItem;
                    }
                    else
                    {
                        MessageBox.Show("Wystąpił błąd podczas edytowania urządzenia. Spróbuj ponownie");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExpanderSearchClick(object sender, RoutedEventArgs e)
        {
            DevicePresenter presenter = (DevicePresenter)this.DataContext;
            Button btn = sender as Button;

            if (btn == null) return;
            switch (btn.Name)
            {
                case "btnGetById":
                    Execute(new GetDataDelegate(presenter.GetDeviceById));
                    break;

                case "btnGetByPeripheralDevice":
                    Execute(new GetDataDelegate(presenter.GetDevicesByPeripheralDeviceName));
                    break;
                
                case "btnGetBySerialNumber":
                    Execute(new GetDataDelegate(presenter.GetDevicesBySerialNumber));
                    break;

                case "btnGetByIP":
                    Execute(new GetDataDelegate(presenter.GetDevicesByIPAddress));
                    break;
                   
                case "btnGetByMac":
                    Execute(new GetDataDelegate(presenter.GetDeviceByMacAddress));
                    break;
                    
                case "btnGetByProducer":
                    Execute(new GetDataDelegate(presenter.GetDevicesByProducer));
                    break;
                    
                case "btnGetByModel":
                    Execute(new GetDataDelegate(presenter.GetDevicesByModel));
                    break;
                    
                case "btnGetByIDFixedAsset":
                    Execute(new GetDataDelegate(presenter.GetDeviceByIDFixedAsset));
                    break;
            }
        }

        private void ChangeCurrentRow(DevicePresenter devicePresenter, DeviceEditPresenter deviceEdit,
                DeviceModel obj)
        {
            DeviceModel device = ((DeviceModel)deviceEdit.View.DataContext);
            obj.comment = device.comment;
            obj.id = device.id;
            obj.id_fixed_asset = device.id_fixed_asset;
            obj.id_peripheral_device = device.id_peripheral_device;
            obj.ip_address = device.ip_address;
            obj.mac_address = device.mac_address;
            obj.model = device.model;
            obj.name_peripheral_device = device.name_peripheral_device;
            obj.producer = device.producer;
            obj.serial_number = device.serial_number;
            devicePresenter.View.dataGridDevices.Items.Refresh();
        }
    }
}
