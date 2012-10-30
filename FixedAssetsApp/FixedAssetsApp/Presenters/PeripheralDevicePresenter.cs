using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Concrete;
using System.Windows.Threading;
using System.Windows.Forms;

namespace FixedAssetsApp.Presenters
{
    public sealed class PeripheralDevicePresenter : PresenterBase<PeripheralDeviceView>
    {
        public PeripheralDevicePresenter(PeripheralDeviceView view)
            : base(view)
        {
        }

        public void ClearDataGridList()
        {
            View.dataGridPeripheralDevices.ItemsSource = null;
            View.dataGridPeripheralDevices.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<PeripheralDevice> list)
        {
            ClearDataGridList();
            View.dataGridPeripheralDevices.ItemsSource = list;
            View.dataGridPeripheralDevices.SelectedIndex = 0;
        }

        public void GetAllPeripheralDevices()
        {
            ObservableCollection<PeripheralDevice> list;
            using (PeripheralDeviceServiceClient client = new PeripheralDeviceServiceClient())
            {
                client.Open();
                PeripheralDeviceMethods pm = new PeripheralDeviceMethods();
                list = pm.CreatePeripheralDevicesList();
                client.Close();
            }
            this.View.dataGridPeripheralDevices.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                if (list.Count == 0) return;
                AddItemsSourceToDataGridList(list);
            }));
        }

        public void SavePeripheralDevice(PeripheralDevice device, bool isEdit)
        {
            using (PeripheralDeviceTransactionsClient client = new PeripheralDeviceTransactionsClient())
            {
                try
                {
                    client.Open();
                    if (isEdit)
                    {
                        client.EditPeripheralDevice(device);
                        MessageBox.Show("Urządzenie: " + device.name + " zostało zaktualizowane");
                    }
                    else
                    {
                        client.AddPeripheralDevice(device);
                        MessageBox.Show("Urządzenie: " + device.name + " zostało dodane");
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void DeletePeripheralDevice(PeripheralDevice device)
        {
            using (PeripheralDeviceTransactionsClient client = new PeripheralDeviceTransactionsClient())
            {
                try
                {
                    PeripheralDevice temp = null;
                    temp = device;

                    if (temp != null)
                    {
                        client.Open();
                        client.DeletePeripheralDevice(temp);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridPeripheralDevices.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }    
        }
    }
}
