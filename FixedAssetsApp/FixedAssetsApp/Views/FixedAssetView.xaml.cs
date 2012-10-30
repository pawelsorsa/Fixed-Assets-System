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
    /// Interaction logic for FixedAssetView.xaml
    /// </summary>
    public partial class FixedAssetView : UserControl
    {
        private delegate void GetDataDelegate();
        public FixedAssetView()
        {
            InitializeComponent();
            DataContext = new FixedAssetPresenter(this);
        }

        private void Execute(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btn_GetAllFixedAssets_Click(object sender, RoutedEventArgs e)
        {
            FixedAssetPresenter presenter = (FixedAssetPresenter)this.DataContext;
            Execute(presenter.GetAllFixedAssets);
        }

        private void btn_AddFixedAsset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FixedAssetEditPresenter fixedAssetEditPresenter = new FixedAssetEditPresenter(new FixedAssetEditView(), new FixedAsset());
                FixedAsset asset = (FixedAsset)(fixedAssetEditPresenter.View.DataContext);
                fixedAssetEditPresenter.View.Label_AddOrEditFixedAsset.Content = "Dodawanie środka trwałego";
                FixedAssetPresenter fixedPresenter = (FixedAssetPresenter)this.DataContext;
                if (asset != null)
                {
                    fixedAssetEditPresenter.View.ShowDialog();
                    if (fixedAssetEditPresenter.View.DialogResult == true)
                    {
                        fixedPresenter.SaveFixedAsset(asset, false);
                        fixedPresenter.GetAllFixedAssets();
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania środka trwałego. Spróbuj ponownie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridFixedAssets_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        FixedAssetPresenter fixedAssetPresenter = (FixedAssetPresenter)this.DataContext;
                        var asset = (FixedAsset)this.dataGridFixedAssets.SelectedItem;
                        if (asset != null)
                        {
                            fixedAssetPresenter.DeleteFixedAsset((FixedAsset)asset);
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
                FixedAssetPresenter fixedAssetPresenter = (FixedAssetPresenter)this.DataContext;
                FixedAsset asset = new FixedAsset();
                DeepClone.CopyTo((FixedAsset)(fixedAssetPresenter.View.dataGridFixedAssets.SelectedItem), asset);
                FixedAssetEditPresenter fixedAssetEditPresenter = new FixedAssetEditPresenter(new FixedAssetEditView(), asset);
                CustomizeComboBoxes(fixedAssetEditPresenter, asset);
                fixedAssetEditPresenter.View.Label_AddOrEditFixedAsset.Content = "Edytowanie środka trwałego";
                if (fixedAssetEditPresenter.View.ShowDialog() == true)
                {
                    asset.last_modified_date = DateTime.Now;
                    fixedAssetPresenter.SaveFixedAsset(asset, true);
                    FixedAsset temp = (FixedAsset)fixedAssetPresenter.View.dataGridFixedAssets.SelectedItem;
                    ChangeCurrentRow(fixedAssetPresenter, fixedAssetEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeCurrentRow(FixedAssetPresenter fixedAssetPresenter, FixedAssetEditPresenter fixedassetEdit,
          FixedAsset obj)
        {
            FixedAsset asset = ((FixedAsset)fixedassetEdit.View.DataContext);
            obj.id = asset.id;
            obj.cassation = asset.cassation;
            obj.comment = asset.comment;
            obj.created_by = asset.created_by;
            obj.date_of_activation = asset.date_of_activation;
            obj.date_of_desactivation = asset.date_of_desactivation;
            obj.id_contractor = asset.id_contractor;
            obj.id_kind = asset.id_kind;
            obj.id_person = asset.id_person;
            obj.id_subgroup = asset.id_subgroup;
            obj.inventory_number = asset.inventory_number;
            obj.last_modifed_login = asset.last_modifed_login;
            obj.last_modified_date = asset.last_modified_date;
            obj.localization = asset.localization;
            obj.MPK = asset.MPK;
            obj.quantity = asset.quantity;
            obj.serial_number = asset.serial_number;
            fixedAssetPresenter.View.dataGridFixedAssets.Items.Refresh();
        }

        private void CustomizeComboBoxes(FixedAssetEditPresenter fixedAssetEditPresenter, FixedAsset asset)
        {
            KindMethods kindMethods = new KindMethods();
            SubgroupMethods subgroupMethods = new SubgroupMethods();
            PersonMethods personMethods = new PersonMethods();
            fixedAssetEditPresenter.View.ComboBox_Id_Kind.ItemsSource = kindMethods.GetAllKindsAsStringArray();
            fixedAssetEditPresenter.View.ComboBox_id_subgroup.ItemsSource = subgroupMethods.GetAllSubgroupsAsStringArray();
            fixedAssetEditPresenter.View.ComboBox_Id_Kind.SelectedValue = KindMethods.GetNameByIdWebServiceMethod((int)asset.id_kind);
            fixedAssetEditPresenter.View.ComboBox_id_subgroup.SelectedValue = SubgroupMethods.GetNameByIdWebServiceMethod((int)asset.id_subgroup, false);
            fixedAssetEditPresenter.View.ComboBox_casation.ItemsSource = new List<string>() { "TAK", "NIE" };
            fixedAssetEditPresenter.View.ComboBox_Id_Person.ItemsSource = personMethods.GetAllPersonsAsStringArray();
            if (asset.cassation) { fixedAssetEditPresenter.View.ComboBox_casation.SelectedValue = "TAK"; }
            else { fixedAssetEditPresenter.View.ComboBox_casation.SelectedValue = "NIE"; }
            bool isChecked = asset.date_of_desactivation.HasValue ? true : false;
            fixedAssetEditPresenter.View.checkBoxDesactivation.IsChecked = isChecked;
            string person_name = personMethods.GetNameSurnameIdByID((int)asset.id_person).Trim();
            fixedAssetEditPresenter.View.ComboBox_Id_Person.SelectedValue = person_name;
        }

        private void btnExpanderSearchClick(object sender, RoutedEventArgs e)
        {
            FixedAssetPresenter presenter = (FixedAssetPresenter)this.DataContext;
            Button btn = sender as Button;

            if (btn == null) return;
            switch (btn.Name)
            {
                case "btnGetById":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetById));
                    break;
                case "btnGetByInventoryNumber":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetByInventoryNumber));
                    break;
                case "btnGetBySerialNumber":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetBySerialNumber));
                    break;
                case "btnGetByActivationDate":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetByActivationDateRange));
                    break;
                case "btnGetByContractor":
                  //  Execute(new GetDataDelegate(presenter.GetFixedAssetByContractor));
                    break;
                case "btnGetByKind":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetByKind));
                    break;
                case "btnGetByLocalization":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetByLocalization));
                    break;
                case "btnGetByLastModifyDate":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetByLastModyfiedDateRange));
                    break;
                case "btnGetByMPK":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetByMPK));
                    break;
                case "btnGetByOwner":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetByOwner));
                    break;
                case "btnGetBySubgroup":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetBySubgroup));
                    break;
                case "btnGetByCassation":
                    Execute(new GetDataDelegate(presenter.GetFixedAssetsByCassation));
                    break;
  
            }
        }

        private void dataGridFixedAssets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            FixedAsset asset = (FixedAsset)grid.SelectedItem;

            FixedAssetCardPresenter presenter = new FixedAssetCardPresenter(new FixedAssetCardView(), asset);
            presenter.View.ShowDialog();
        }
    }
}
