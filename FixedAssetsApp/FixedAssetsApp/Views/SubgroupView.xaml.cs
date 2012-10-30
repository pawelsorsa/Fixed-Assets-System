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
    /// Interaction logic for Subgroup.xaml
    /// </summary>
    public partial class SubgroupView : UserControl
    {
        private delegate void GetDataDelegate();
        public SubgroupView()
        {
            InitializeComponent();
            DataContext = new SubgroupPresenter(this);
        }

        private void Execute(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btn_GetAllSubgroups_Click(object sender, RoutedEventArgs e)
        {
            SubgroupPresenter presenter = (SubgroupPresenter)this.DataContext;
            Execute(presenter.GetAllSubgroups);
        }

        private void btn_AddSubgroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SubgroupEditPresenter subgroupEditPresenter = new SubgroupEditPresenter(new SubgroupEditView(), new Subgroup());
                Subgroup subgroup = (Subgroup)(subgroupEditPresenter.View.DataContext);
                subgroupEditPresenter.View.Label_AddOrEditSubgroup.Content = "Dodawanie podgrupy";
                SubgroupPresenter subgroupPresenter = (SubgroupPresenter)this.DataContext;
                if (subgroup != null)
                {
                    subgroupEditPresenter.View.ShowDialog();
                    if (subgroupEditPresenter.View.DialogResult == true)
                    {
                        subgroupPresenter.SaveSubgroup(subgroup, false);
                        subgroupPresenter.GetAllSubgroups();
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania podgrupy. Spróbuj ponownie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridSubgroups_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SubgroupPresenter subgroupPresenter = (SubgroupPresenter)this.DataContext;
                        var subgroup = (Subgroup)this.dataGridSubgroups.SelectedItem;
                        if (subgroup != null)
                        {
                            subgroupPresenter.DeleteSubgroup((Subgroup)subgroup);
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
                SubgroupPresenter subgroupPresenter = (SubgroupPresenter)this.DataContext;
                Subgroup subgroup = new Subgroup();
                DeepClone.CopyTo((Subgroup)(subgroupPresenter.View.dataGridSubgroups.SelectedItem), subgroup);
                SubgroupEditPresenter subgroupEditPresenter = new SubgroupEditPresenter(new SubgroupEditView(), subgroup);
                subgroupEditPresenter.View.Label_AddOrEditSubgroup.Content = "Edytowanie podgrupy";
                if (subgroupEditPresenter.View.ShowDialog() == true)
                {
                    subgroupPresenter.SaveSubgroup(subgroup, true);
                    Subgroup temp = (Subgroup)subgroupPresenter.View.dataGridSubgroups.SelectedItem;
                    ChangeCurrentRow(subgroupPresenter, subgroupEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeCurrentRow(SubgroupPresenter subgroupPresenter, SubgroupEditPresenter subgroupEdit,
          Subgroup obj)
        {
            Subgroup subgroup = ((Subgroup)subgroupEdit.View.DataContext);
            obj.id = subgroup.id;
            obj.short_name = subgroup.short_name;
            obj.name = subgroup.name;
            subgroupPresenter.View.dataGridSubgroups.Items.Refresh();
        }

    }
}
