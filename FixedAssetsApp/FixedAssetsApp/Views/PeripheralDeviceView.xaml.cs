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
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Concrete;
using System.Threading;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for PeripheralDeviceView.xaml
    /// </summary>
    public partial class PeripheralDeviceView : UserControl
    {
        public PeripheralDeviceView()
        {
            InitializeComponent();
            DataContext = new PeripheralDevicePresenter(this);
        }

        private delegate void GetDataDelegate();
        private void ExecuteThread(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btn_AddPeripheralDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PeripheralDeviceEditPresenter deviceEditPresenter = new PeripheralDeviceEditPresenter(new PeripheralDeviceEditView(), new PeripheralDevice());
                PeripheralDevice device = (PeripheralDevice)(deviceEditPresenter.View.DataContext);
                deviceEditPresenter.View.Label_AddOrEditPeripheral.Content = "Dodawanie urządzenia peryferyjnego";
                PeripheralDevicePresenter peripheralPresenter = (PeripheralDevicePresenter)this.DataContext;
                if (device != null)
                {
                    deviceEditPresenter.View.ShowDialog();
                    if (deviceEditPresenter.View.DialogResult == true)
                    {
                        peripheralPresenter.SavePeripheralDevice(device, false);
                        peripheralPresenter.GetAllPeripheralDevices();
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania urządzenia. Spróbuj ponownie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PeripheralDevicePresenter peripheralPresenter = (PeripheralDevicePresenter)this.DataContext;
                PeripheralDevice device = new PeripheralDevice();
                DeepClone.CopyTo((PeripheralDevice)(peripheralPresenter.View.dataGridPeripheralDevices.SelectedItem), device); 

                PeripheralDeviceEditPresenter peripheralEditPresenter = new PeripheralDeviceEditPresenter(new PeripheralDeviceEditView(), device);
                peripheralEditPresenter.View.Label_AddOrEditPeripheral.Content = "Edytowanie urządzenia peryferyjnego";

                if (peripheralEditPresenter.View.ShowDialog() == true)
                {
                    peripheralPresenter.SavePeripheralDevice(device, true);
                    PeripheralDevice temp = (PeripheralDevice)peripheralPresenter.View.dataGridPeripheralDevices.SelectedItem;
                    ChangeCurrentRow(peripheralPresenter, peripheralEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridPeripheralDevices_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        PeripheralDevicePresenter peripheralPresenter = (PeripheralDevicePresenter)this.DataContext;
                        var peripheral = (PeripheralDevice)this.dataGridPeripheralDevices.SelectedItem;
                        if (peripheral != null)
                        {
                            peripheralPresenter.DeletePeripheralDevice((PeripheralDevice)peripheral);
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

        private void ChangeCurrentRow(PeripheralDevicePresenter devicePresenter, PeripheralDeviceEditPresenter deviceEdit,
           PeripheralDevice obj)
        {
            PeripheralDevice device = ((PeripheralDevice)deviceEdit.View.DataContext);
            obj.id = device.id;
            obj.name = device.name;
            devicePresenter.View.dataGridPeripheralDevices.Items.Refresh();
        }

        private void btn_GetAllDevices_Click(object sender, RoutedEventArgs e)
        {
            PeripheralDevicePresenter presenter = (PeripheralDevicePresenter)this.DataContext;
            ExecuteThread(presenter.GetAllPeripheralDevices);
        }

    }
}
