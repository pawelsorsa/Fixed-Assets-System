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
    public sealed class SubgroupPresenter : PresenterBase<SubgroupView>
    {
        public SubgroupPresenter(SubgroupView view)
            : base(view)
        {
        }

        public void ClearDataGridList()
        {
            View.dataGridSubgroups.ItemsSource = null;
            View.dataGridSubgroups.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<Subgroup> list)
        {
            ClearDataGridList();
            View.dataGridSubgroups.ItemsSource = list;
            View.dataGridSubgroups.SelectedIndex = 0;
        }

        public void GetAllSubgroups()
        {
            ObservableCollection<Subgroup> list;
            using (SubgroupServiceClient client = new SubgroupServiceClient())
            {
                SubgroupMethods subgroupMethods = new SubgroupMethods();
                client.Open();
                list = subgroupMethods.CreateSubgroupsList();
                client.Close();
            }
            this.View.dataGridSubgroups.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                if (list.Count == 0) return;
                AddItemsSourceToDataGridList(list);
            }));
        }

        public void SaveSubgroup(Subgroup subgroup, bool isEdit)
        {
            using (SubgroupTransactionsClient client = new SubgroupTransactionsClient())
            {
                try
                {
                    client.Open();
                    if (isEdit)
                    {
                        client.EditSubgroup(subgroup);
                        MessageBox.Show("Podgrupa: " + subgroup.short_name + " została zaktualizowana");
                    }
                    else
                    {
                        client.AddSubgroup(subgroup);
                        MessageBox.Show("Podgrupa: " + subgroup.short_name + " została dodana");
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void DeleteSubgroup(Subgroup subgroup)
        {
            using (SubgroupTransactionsClient client = new SubgroupTransactionsClient())
            {
                try
                {
                    Subgroup temp = null;
                    temp = subgroup;

                    if (temp != null)
                    {
                        client.Open();
                        client.DeleteSubgroup(temp);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridSubgroups.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }    
        }
    }
}
