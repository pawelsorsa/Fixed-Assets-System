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
using System.Globalization;
using System.Text.RegularExpressions;

namespace FixedAssetsApp.Presenters
{
    public sealed class FixedAssetPresenter : PresenterBase<FixedAssetView>
    {
        private FixedAssetMethods fixedAssetsMethods;
        public FixedAssetPresenter(FixedAssetView view)
            : base(view)
        {
            fixedAssetsMethods = new FixedAssetMethods();
        }

        public void ClearDataGridList()
        {
            View.dataGridFixedAssets.ItemsSource = null;
            View.dataGridFixedAssets.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<FixedAsset> list)
        {
            ClearDataGridList();
            View.dataGridFixedAssets.ItemsSource = list;
            View.dataGridFixedAssets.SelectedIndex = 0;
        }

        public void GetAllFixedAssets()
        {
            ObservableCollection<FixedAsset> list;
            using (FixedAssetServiceClient client = new FixedAssetServiceClient())
            {
                client.Open();
                FixedAssetMethods fm = new FixedAssetMethods();
                list = fm.CreateFixedAssetList();
                client.Close();
            }
            this.View.dataGridFixedAssets.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                if (list.Count == 0) return;
                AddItemsSourceToDataGridList(list);
            }));
        }


        public void GetFixedAssetById()
        {
            try
            {
                FixedAsset asset;
                ObservableCollection<FixedAsset> list;
                int id = 0;

                this.View.tbId.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (!(int.TryParse(this.View.tbId.Text, out id))) { return; }
                }));

                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    asset = client.GetFixedAssetById(id);
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (asset == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAsset>();
                    list.Add(asset);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetFixedAssetByInventoryNumber()
        {
            try
            {
                FixedAsset asset;
                ObservableCollection<FixedAsset> list;
                string inverntory_number = string.Empty;

                this.View.tbInventoryNumber.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((inverntory_number = this.View.tbInventoryNumber.Text) == string.Empty) { return; }
                }));

                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    asset = client.GetFixedAssetByInventoryNumber(inverntory_number);
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (asset == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAsset>();
                    list.Add(asset);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetFixedAssetBySerialNumber()
        {
            try
            {
                FixedAsset asset;
                ObservableCollection<FixedAsset> list;
                string serial_number = string.Empty;

                this.View.tbSerialNumber.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((serial_number = this.View.tbSerialNumber.Text) == string.Empty) { return; }
                }));

                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    asset = client.GetFixedAssetBySerialNumber(serial_number);
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (asset == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAsset>();
                    list.Add(asset);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetFixedAssetByActivationDateRange()
        {
            try
            {
                ObservableCollection<FixedAsset> list;
                DateTime startDate = new DateTime();
                DateTime stopDate = new DateTime();
                bool error = false;

                this.View.tbActivationDate.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    string start = this.View.tbActivationDate.Text;
                    if (start == string.Empty) return;
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "yyyy-MM-dd";
                    dtfi.DateSeparator = "-";
                    if (!DateTime.TryParse(start, out startDate))
                    {
                        error = true;
                    }
                }));

                this.View.tbActivationDate2.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    string start = this.View.tbActivationDate2.Text;
                    if (start == string.Empty) return;
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "yyyy-MM-dd";
                    dtfi.DateSeparator = "-";
                    if (!DateTime.TryParse(start, out stopDate))
                    {
                        error = true;
                    }
                }));

                if (error)
                {
                    MessageBox.Show("Podana data ma nieprawidłowy format.\nData powinna mieć następujący format: rrrr-mm-dd.\nPopraw i spróbuj ponownie");
                }
                else
                {
                    using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                    {
                        client.Open();
                        list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByRangeActivationDate(startDate, stopDate));
                    }

                    this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                    {
                        if (list.Count == 0) { ClearDataGridList(); return; }
                        AddItemsSourceToDataGridList(list);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetFixedAssetByLastModyfiedDateRange()
        {
            try
            {
                ObservableCollection<FixedAsset> list;
                DateTime startDate = new DateTime();
                DateTime stopDate = new DateTime();
                bool error = false;

                this.View.tbLastModifyDate.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    string start = this.View.tbLastModifyDate.Text;
                    if (start == string.Empty) return;
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "yyyy-MM-dd";
                    dtfi.DateSeparator = "-";
                    if (!DateTime.TryParse(start, out startDate))
                    {
                        error = true;
                    }
                }));

                this.View.tbLastModifyDate2.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    string start = this.View.tbLastModifyDate2.Text;
                    if (start == string.Empty) return;
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    dtfi.ShortDatePattern = "yyyy-MM-dd";
                    dtfi.DateSeparator = "-";
                    if (!DateTime.TryParse(start, out stopDate))
                    {
                        error = true;
                    }
                }));

                if (error)
                {
                    MessageBox.Show("Podana data ma nieprawidłowy format.\nData powinna mieć następujący format: rrrr-mm-dd.\nPopraw i spróbuj ponownie");
                }
                else
                {
                    using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                    {
                        client.Open();
                        list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByRangeLastModifiedDate(startDate, stopDate));
                    }

                    this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                    {
                        if (list.Count == 0) { ClearDataGridList(); return; }
                        AddItemsSourceToDataGridList(list);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GetFixedAssetByKind()
        {
            try
            {
                string kind = string.Empty;
                this.View.tbKind.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((kind = this.View.tbKind.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAsset> list;
                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    int temp;
                    if(int.TryParse(kind, out temp))
                    {
                        list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByKindId(temp));
                    }
                    else
                    {
                        int id = KindMethods.GetIdByNameWebServiceMethod(kind);
                        list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByKindId(id));
                    }
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
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

        public void GetFixedAssetByLocalization()
        {
            try
            {
                string localization = string.Empty;
                this.View.tbLocalization.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((localization = this.View.tbLocalization.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAsset> list;
                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByLocalization(localization));
                    client.Close();
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
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


        public void GetFixedAssetByMPK()
        {
            try
            {
                string mpk = string.Empty;
                this.View.tbMPK.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((mpk = this.View.tbMPK.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAsset> list;
                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByMPK(mpk));
                    client.Close();
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
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

        public void GetFixedAssetByOwner()
        {
            try
            {
                string person = string.Empty;
                this.View.tbOwner.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((person = this.View.tbOwner.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAsset> list;
                list = new ObservableCollection<FixedAsset>();
                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    int temp;
                    if (int.TryParse(person, out temp))
                    {
                        list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByPersonId(temp));
                    }
                    else
                    {
                        using (PersonServiceClient client2 = new PersonServiceClient())
                        {
                            string [] tab = Regex.Split(person, " ");
                            if (tab.Count() == 2)
                            {
                                object[] lista = client2.GetPersonsByNameAndSurname(tab[1], tab[0]);
                                if (lista.Count() > 0)
                                {
                                    Person person_temp = (Person)lista[0];
                                    if (person_temp != null)
                                    {
                                        list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByPersonId(person_temp.id));
                                    }
                                }
                                else
                                {
                                    lista = client2.GetPersonsByNameAndSurname(tab[0], tab[1]);
                                    if (lista.Count() > 0)
                                    {
                                        Person person_temp = (Person)lista[0];
                                        if (person_temp != null)
                                        {
                                            list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsByPersonId(person_temp.id));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
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


        public void GetFixedAssetBySubgroup()
        {
            try
            {
                string subgroup = string.Empty;
                this.View.tbSubgroup.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((subgroup = this.View.tbSubgroup.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAsset> list = new ObservableCollection<FixedAsset>();
                int id_subgroup;
                if (int.TryParse(subgroup, out id_subgroup))
                {
                    using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                    {
                        client.Open();
                        list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsBySubgroupId(id_subgroup));
                        client.Close();
                    }
                }
                else
                {
                    Subgroup subgroup_temp;
                    using (SubgroupServiceClient client = new SubgroupServiceClient())
                    {
                        client.Open();
                        subgroup_temp = (Subgroup)client.GetSubgroupByShortName(subgroup);
                        client.Close();
                    }
                    if (subgroup_temp != null)
                    {
                        using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                        {
                            client.Open();
                            list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsBySubgroupId(subgroup_temp.id));
                            client.Close();
                        }
                    }
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
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

        public void GetFixedAssetsByCassation()
        {
            try
            {
                ObservableCollection<FixedAsset> list;
                using (FixedAssetServiceClient client = new FixedAssetServiceClient())
                {
                    client.Open();
                    list = fixedAssetsMethods.CreateFixedAssetList(client.GetFixedAssetsToCassation());
                    client.Close();
                }

                this.View.dataGridFixedAssets.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
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



        public void SaveFixedAsset(FixedAsset asset, bool isEdit)
        {
            using (FixedAssetTransactionsClient client = new FixedAssetTransactionsClient())
            {
                try
                {
                    client.Open();
                    if (isEdit)
                    {
                        client.EditFixedAsset(asset);
                        MessageBox.Show("Środek trwały: " + asset.id + " został zaktualizowany");
                    }
                    else
                    {
                        client.AddFixedAsset(asset);
                        MessageBox.Show("Środek trwały: " + asset.id + " został dodany");
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void DeleteFixedAsset(FixedAsset asset)
        {
            using (FixedAssetTransactionsClient client = new FixedAssetTransactionsClient())
            {
                try
                {
                    FixedAsset temp = null;
                    temp = asset;

                    if (temp != null)
                    {
                        client.Open();
                        client.DeleteFixedAsset(temp);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridFixedAssets.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }    
        }
    }
}
