using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Concrete;
using System.Windows.Threading;
using FixedAssetsApp.Model;
using System.Windows.Forms;

namespace FixedAssetsApp.Presenters
{
    public sealed class DevicePresenter : PresenterBase<DeviceView>
    {
        private DeviceMethods deviceMethods;
        public DevicePresenter(DeviceView view)
            :base(view)
        {
            deviceMethods = new DeviceMethods();
        }

        public void ClearDataGridList()
        {
            View.dataGridDevices.ItemsSource = null;
            View.dataGridDevices.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<DeviceModel> list)
        {
            ClearDataGridList();
            View.dataGridDevices.ItemsSource = list;
            View.dataGridDevices.SelectedIndex = 0;
        }

        public void GetAllDevices()
        {
            ObservableCollection<DeviceModel> list;
            using (DeviceServiceClient client = new DeviceServiceClient())
            {
                client.Open();
               // System.Threading.Thread.Sleep(5000);
                list = DeviceMethods.CreateDevicesList(client.GetAllDevices());
                client.Close();
            }

            this.View.dataGridDevices.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                if (list.Count == 0) return;
                AddItemsSourceToDataGridList(list);
            }));
        }

        public void GetDeviceById()
        {
            try
            {
                DeviceModel device;
                Device temp;
                ObservableCollection<DeviceModel> list;
                int id = 0;

                this.View.tbId.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (!(int.TryParse(this.View.tbId.Text, out id))) { return; }
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    client.Open();
                    temp = client.GetDeviceById(id);
                    client.Close();
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (temp == null) { ClearDataGridList(); return; }
                    device = DeviceMethods.CreateDeviceModel(temp);
                    list = new ObservableCollection<DeviceModel>();
                    list.Add(device);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetDevicesByPeripheralDeviceName()
        {
            try
            {
                ObservableCollection<DeviceModel> list;
                string name = string.Empty;

                this.View.ComboBox_Devies.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((name = this.View.ComboBox_Devies.Text.Trim()) == string.Empty) return;
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    client.Open();
                    int id = PeripheralDeviceMethods.GetIdByNameWebServiceMethod(name);
                    if (id == 0) return;
                    list = DeviceMethods.CreateDevicesList(client.GetDevicesByPheripheralDeviceId(id));
                    client.Close();
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetDevicesBySerialNumber()
        {
            try
            {
                ObservableCollection<DeviceModel> list;
                string sn = string.Empty;

                this.View.tbSerialNumber.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((sn = this.View.tbSerialNumber.Text.Trim()) == string.Empty) return;
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    if (sn != string.Empty)
                    {
                        client.Open();
                        list = DeviceMethods.CreateDevicesList(client.GetDevicesBySerialNumber(sn));
                        client.Close();
                    }
                    else
                    {
                        list = new ObservableCollection<DeviceModel>();
                    }
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetDevicesByIPAddress()
        {
            try
            {
                ObservableCollection<DeviceModel> list;
                string ip = string.Empty;

                this.View.tbIP.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((ip = this.View.tbIP.Text.Trim()) == string.Empty) return;
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    if (ip != string.Empty)
                    {
                        client.Open();
                        list = DeviceMethods.CreateDevicesList(client.GetDevicesByIpAddress(ip));
                        client.Close();
                    }
                    else
                    {
                        list = new ObservableCollection<DeviceModel>();
                    }
                    
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetDeviceByMacAddress()
        {
            try
            {
                ObservableCollection<DeviceModel> list;
                Device temp;
                DeviceModel device;
                string mac = string.Empty;

                this.View.tbMAC.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((mac = this.View.tbMAC.Text.Trim()) == string.Empty) return;
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    if (mac == string.Empty) { return; } 
                    client.Open();
                    temp = client.GetDeviceByMacAddress(mac);
                    client.Close();
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (temp == null) { ClearDataGridList(); return; }
                    device = DeviceMethods.CreateDeviceModel(temp);
                    list = new ObservableCollection<DeviceModel>();
                    list.Add(device);
                    AddItemsSourceToDataGridList(list);

                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetDevicesByProducer()
        {
            try
            {
                ObservableCollection<DeviceModel> list;
                string producer = string.Empty;

                this.View.tbProducer.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((producer = this.View.tbProducer.Text.Trim()) == string.Empty) return;
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    if (producer != string.Empty)
                    {
                        client.Open();
                        list = DeviceMethods.CreateDevicesList(client.GetDevicesByProducer(producer));
                        client.Close();
                    }
                    else
                    {
                        list = new ObservableCollection<DeviceModel>();
                    }
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GetDevicesByModel()
        {
            try
            {
                ObservableCollection<DeviceModel> list;
                string model = string.Empty;

                this.View.tbModel.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((model = this.View.tbModel.Text.Trim()) == string.Empty) return;
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    
                    if (model != string.Empty)
                    {
                        client.Open();
                        list = DeviceMethods.CreateDevicesList(client.GetDevicesByModel(model));
                        client.Close();
                    }
                    else
                    {
                        list = new ObservableCollection<DeviceModel>();
                    }
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GetDeviceByIDFixedAsset()
        {
            try
            {
                DeviceModel device;
                Device temp;
                ObservableCollection<DeviceModel> list;
                int id = 0;

                this.View.tbIDFixedAsset.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (!(int.TryParse(this.View.tbIDFixedAsset.Text, out id))) { return; }
                }));

                using (DeviceServiceClient client = new DeviceServiceClient())
                {
                    client.Open();
                    list = DeviceMethods.CreateDevicesList(client.GetDevicesByFixedAssetId(id));
                    client.Close();
                }

                this.View.dataGridDevices.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteDevice(DeviceModel dev)
        {
            using (DeviceTransactionsClient client = new DeviceTransactionsClient())
            {
                try
                {
                    Device temp = null;
                    temp = DeviceMethods.CreateDevice(dev);

                    if (temp != null)
                    {
                        client.Open();
                        client.DeleteDevice(temp);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridDevices.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }       
        }

        public void SaveDevice(DeviceModel dev, bool isEdit)
        {
            using (DeviceTransactionsClient client = new DeviceTransactionsClient())
            {
                try
                {
                    Device device = DeviceMethods.CreateDevice(dev);
                    if (device == null)
                    {
                        MessageBox.Show("Nie udało się edytować urządzenia");
                        return;
                    }

                    client.Open();
                    if (isEdit)
                    {
                        client.EditDevice(device);
                        MessageBox.Show("Urządzenie zostało zaktualizowane");
                    }
                    else
                    {
                        client.AddDevice(device);
                        MessageBox.Show("Urządzenie zostało dodane");
                        this.GetAllDevices();
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
