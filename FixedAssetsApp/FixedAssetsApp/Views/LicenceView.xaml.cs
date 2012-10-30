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
    /// Interaction logic for LicenceView.xaml
    /// </summary>
    public partial class LicenceView : UserControl
    {
        private delegate void GetDataDelegate();
        public LicenceView()
        {
            InitializeComponent();
            DataContext = new LicencePresenter(this);
        }

        private void Execute(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btn_AddLicence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LicenceEditPresenter licenceEditPresenter = new LicenceEditPresenter(new LicenceEditView(), new Licence());
                Licence licence = (Licence)(licenceEditPresenter.View.DataContext);
                licenceEditPresenter.View.Label_AddOrEditLicence.Content = "Dodawanie licencji";
                LicencePresenter licencePresenter = (LicencePresenter)this.DataContext;
                if (licence != null)
                {
                    licenceEditPresenter.View.ShowDialog();
                    if (licenceEditPresenter.View.DialogResult == true)
                    {
                        licencePresenter.SaveLicence(licence, false);
                        licencePresenter.GetAllLicences();
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania licencji. Spróbuj ponownie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_GetAllLicences_Click(object sender, RoutedEventArgs e)
        {
            LicencePresenter presenter = (LicencePresenter)this.DataContext;
            Execute(presenter.GetAllLicences);
        }

        private void dataGridLicences_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        LicencePresenter licencePresenter = (LicencePresenter)this.DataContext;
                        var licence = (Licence)this.dataGridLicences.SelectedItem;
                        if (licence != null)
                        {
                            licencePresenter.DeleteLicence((Licence)licence);
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
                LicencePresenter licencePresenter = (LicencePresenter)this.DataContext;
                Licence licence = new Licence();
                DeepClone.CopyTo((Licence)(licencePresenter.View.dataGridLicences.SelectedItem), licence);
                LicenceEditPresenter subgroupEditPresenter = new LicenceEditPresenter(new LicenceEditView(), licence);
                subgroupEditPresenter.View.Label_AddOrEditLicence.Content = "Edytowanie licencji";
                if (subgroupEditPresenter.View.ShowDialog() == true)
                {
                    licencePresenter.SaveLicence(licence, true);
                    Licence temp = (Licence)licencePresenter.View.dataGridLicences.SelectedItem;
                    ChangeCurrentRow(licencePresenter, subgroupEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeCurrentRow(LicencePresenter licencePresenter, LicenceEditPresenter licenceEdit,
          Licence obj)
        {
            Licence licence = ((Licence)licenceEdit.View.DataContext);
            obj.assign_fixed_asset = licence.assign_fixed_asset;
            obj.comment = licence.comment;
            obj.created_by = licence.created_by;
            obj.id_kind = licence.id_kind;
            obj.id_number = licence.id_number;
            obj.inventory_number = licence.inventory_number;
            obj.last_modified_date = licence.last_modified_date;
            obj.last_modified_login = licence.last_modified_login;
            obj.licence_number = licence.licence_number;
            obj.name = licence.name;
            licencePresenter.View.dataGridLicences.Items.Refresh();
        }
    }
}
