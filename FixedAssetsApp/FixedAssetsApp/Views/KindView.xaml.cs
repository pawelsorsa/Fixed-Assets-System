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
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for KindView.xaml
    /// </summary>
    public partial class KindView : UserControl
    {
        private delegate void GetDataDelegate();
        public KindView()
        {
            InitializeComponent();
            DataContext = new KindPresenter(this);
        }

        private void Execute(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btn_AddKind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KindEditPresenter kindEditPresenter = new KindEditPresenter(new KindEditView(), new Kind());
                Kind kind = (Kind)(kindEditPresenter.View.DataContext);
                kindEditPresenter.View.Label_AddOrEditKind.Content = "Dodawanie rodzaju";
                KindPresenter kindPresenter = (KindPresenter)this.DataContext;
                if (kind != null)
                {
                    kindEditPresenter.View.ShowDialog();
                    if (kindEditPresenter.View.DialogResult == true)
                    {
                        kindPresenter.SaveKind(kind, false);
                        kindPresenter.GetAllKinds();
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania rodzaju. Spróbuj ponownie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_GetAllKinds_Click(object sender, RoutedEventArgs e)
        {
            KindPresenter presenter = (KindPresenter)this.DataContext;
            Execute(presenter.GetAllKinds);
        }

        private void dataGridKinds_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        KindPresenter kindPresenter = (KindPresenter)this.DataContext;
                        var kind = (Kind)this.dataGridKinds.SelectedItem;
                        if (kind != null)
                        {
                            kindPresenter.DeleteKind((Kind)kind);
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
                KindPresenter kindPresenter = (KindPresenter)this.DataContext;
                Kind kind = new Kind();
                DeepClone.CopyTo((Kind)(kindPresenter.View.dataGridKinds.SelectedItem), kind);
                KindEditPresenter kindEditPresenter = new KindEditPresenter(new KindEditView(), kind);
                kindEditPresenter.View.Label_AddOrEditKind.Content = "Edytowanie rodzaju";
                if (kindEditPresenter.View.ShowDialog() == true)
                {
                    kindPresenter.SaveKind(kind, true);
                    Kind temp = (Kind)kindPresenter.View.dataGridKinds.SelectedItem;
                    ChangeCurrentRow(kindPresenter, kindEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ChangeCurrentRow(KindPresenter kindPresenter, KindEditPresenter kindpEdit,
          Kind obj)
        {
            Kind subgroup = ((Kind)kindpEdit.View.DataContext);
            obj.id = subgroup.id;
            obj.name = subgroup.name;
            kindPresenter.View.dataGridKinds.Items.Refresh();
        }
    }
}
