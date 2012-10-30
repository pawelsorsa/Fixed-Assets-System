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
    public sealed class KindPresenter : PresenterBase<KindView>
    {
        public KindPresenter(KindView view)
            : base(view)
        {
        }

        public void ClearDataGridList()
        {
            View.dataGridKinds.ItemsSource = null;
            View.dataGridKinds.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<Kind> list)
        {
            ClearDataGridList();
            View.dataGridKinds.ItemsSource = list;
            View.dataGridKinds.SelectedIndex = 0;
        }

        public void GetAllKinds()
        {
            ObservableCollection<Kind> list;
            using (KindServiceClient client = new KindServiceClient())
            {
                client.Open();
                KindMethods kindsMethods = new KindMethods();
                list = kindsMethods.CreateKindsList();
                client.Close();
            }
            this.View.dataGridKinds.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                if (list.Count == 0) return;
                AddItemsSourceToDataGridList(list);
            }));
        }

        public void SaveKind(Kind kind, bool isEdit)
        {
            using (KindTransactionsClient client = new KindTransactionsClient())
            {
                try
                {
                    client.Open();
                    if (isEdit)
                    {
                        client.EditKind(kind);
                        MessageBox.Show("Rodzaj: " + kind.name + " został zaktualizowany");
                    }
                    else
                    {
                        client.AddKind(kind);
                        MessageBox.Show("Rodzaj: " + kind.name + " został dodany");
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void DeleteKind(Kind kind)
        {
            using (KindTransactionsClient client = new KindTransactionsClient())
            {
                try
                {
                    Kind temp = null;
                    temp = kind;

                    if (temp != null)
                    {
                        client.Open();
                        client.DeleteKind(temp);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridKinds.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }    
        }
    }
}
