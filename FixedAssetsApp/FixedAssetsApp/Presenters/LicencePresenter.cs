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
    public sealed class LicencePresenter : PresenterBase<LicenceView>
    {
        public LicencePresenter(LicenceView view)
            : base(view)
        {
        }

        public void ClearDataGridList()
        {
            View.dataGridLicences.ItemsSource = null;
            View.dataGridLicences.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<Licence> list)
        {
            ClearDataGridList();
            View.dataGridLicences.ItemsSource = list;
            View.dataGridLicences.SelectedIndex = 0;
        }

        public void GetAllLicences()
        {
            ObservableCollection<Licence> list;
            using (LicenceServiceClient client = new LicenceServiceClient())
            {
                client.Open();
                LicenceMethods licenceMethods = new LicenceMethods();
                list = licenceMethods.CreateLicencesList();
                client.Close();
            }
            this.View.dataGridLicences.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                if (list.Count == 0) return;
                AddItemsSourceToDataGridList(list);
            }));
        }

        public void SaveLicence(Licence licence, bool isEdit)
        {
            using (LicenceTransactionsClient client = new LicenceTransactionsClient())
            {
                try
                {
                    client.Open();
                    licence.id_kind = 6;
                    licence.last_modified_date = DateTime.Now;
                    if (isEdit)
                    {
                        client.EditLicence(licence);
                        MessageBox.Show("Licencja: " + licence.name + " została zaktualizowana");
                    }
                    else
                    {
                        client.AddLicence(licence);
                        MessageBox.Show("Licencja: " + licence.name + " została dodana");
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void DeleteLicence(Licence licence)
        {
            using (LicenceTransactionsClient client = new LicenceTransactionsClient())
            {
                try
                {
                    Licence temp = null;
                    temp = licence;

                    if (temp != null)
                    {
                        client.Open();
                        client.DeleteLicence(temp);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridLicences.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }    
        }
    }
}
