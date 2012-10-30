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
using FixedAssetsApp.Concrete;
using System.Threading;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for SectionView.xaml
    /// </summary>
    public partial class SectionView : UserControl
    {
        private delegate void GetDataDelegate();
        public SectionView()
        {
            InitializeComponent();
            DataContext = new SectionPresenter(this);
        }

        private void Execute(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionPresenter sectionPresenter = (SectionPresenter)this.DataContext;
                SectionMethods sectionMethods = new SectionMethods();
                FixedAssetsApp.FixedAssetsWebService.Section section = sectionMethods.CloneSection((FixedAssetsApp.FixedAssetsWebService.Section)(sectionPresenter.View.dataGridSections.SelectedItem));
                SectionEditPresenter sectionEditPresenter = new SectionEditPresenter(new SectionEditView(), section);
                sectionEditPresenter.View.Label_AddOrEditSection.Content = "Edytowanie sekcji";

                if (sectionEditPresenter.View.ShowDialog() == true)
                {
                    sectionPresenter.SaveSection(section, true);
                    FixedAssetsApp.FixedAssetsWebService.Section temp = (FixedAssetsApp.FixedAssetsWebService.Section)sectionPresenter.View.dataGridSections.SelectedItem;
                    ChangeCurrentRow(sectionPresenter, sectionEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AddSection_Click(object sender, RoutedEventArgs e)
        {
            SectionMethods sectionMethods = new SectionMethods();
            SectionEditPresenter sectionEditPresenter = new SectionEditPresenter(new SectionEditView(), new FixedAssetsApp.FixedAssetsWebService.Section());
            FixedAssetsApp.FixedAssetsWebService.Section section = (FixedAssetsApp.FixedAssetsWebService.Section)(sectionEditPresenter.View.DataContext);
            sectionEditPresenter.View.Label_AddOrEditSection.Content = "Dodawanie sekcji";
            SectionPresenter sectionPresenter = (SectionPresenter)this.DataContext;
            if (section != null)
            {
                sectionEditPresenter.View.ShowDialog();
                if (sectionEditPresenter.View.DialogResult == true)
                {
                    sectionPresenter.SaveSection(section, false);
                    sectionPresenter.GetAllSections();
                }
            }
            else
            {
                MessageBox.Show("Wystąpił błąd podczas dodawania sekcji. Spróbuj ponownie");
            }
        }

        private void dataGridSections_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {              
                        SectionPresenter sectionPresenter = (SectionPresenter)this.DataContext;
                        var section = (FixedAssetsApp.FixedAssetsWebService.Section)this.dataGridSections.SelectedItem;
                        if (section != null)
                        {
                            sectionPresenter.DeleteSection((FixedAssetsApp.FixedAssetsWebService.Section)section);
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


        private void btn_GetAllSections_Click(object sender, RoutedEventArgs e)
        {
            SectionPresenter presenter = (SectionPresenter)this.DataContext;
            Execute(new GetDataDelegate(presenter.GetAllSections));
        }

        private void btnExpanderSearchClick(object sender, RoutedEventArgs e)
        {
            SectionPresenter presenter = (SectionPresenter)this.DataContext;
            Button btn = sender as Button;

            if (btn == null) return;
            switch (btn.Name)
            {
                case "btnGetById":
                    Execute(new GetDataDelegate(presenter.GetSectionById));
                    break;
                case "btnGetByName":
                    Execute(new GetDataDelegate(presenter.GetSectionByName));
                    break;

                case "btnGetShortName":
                    Execute(new GetDataDelegate(presenter.GetSectionByShortName));
                    break;

                case "btnGetByStreet":
                    Execute(new GetDataDelegate(presenter.GetSectionByAddress));
                    break;

                case "btnGetByPostalCode":
                    Execute(new GetDataDelegate(presenter.GetSectionByPostalCode));
                    break;

                case "btnGetByPost":
                    Execute(new GetDataDelegate(presenter.GetSectionByPost));
                    break;

                case "btnGetByLocacity":
                    Execute(new GetDataDelegate(presenter.GetSectionByLocacity));
                    break;

                case "btnGetByPhone":
                    Execute(new GetDataDelegate(presenter.GetSectionByPhone));
                    break;

                case "btnGetByEmail":
                    Execute(new GetDataDelegate(presenter.GetSectionByEmail));
                    break;
            }
        }


        private void ChangeCurrentRow(SectionPresenter sectionPresenter, SectionEditPresenter sectionEdit,
            FixedAssetsApp.FixedAssetsWebService.Section obj)
        {
            FixedAssetsApp.FixedAssetsWebService.Section section = ((FixedAssetsApp.FixedAssetsWebService.Section)sectionEdit.View.DataContext);
            obj.email = section.email;
            obj.id = section.id;
            obj.locality = section.locality;
            obj.name = section.name;
            obj.phone_number = section.phone_number;
            obj.post = section.post;
            obj.postal_code = section.postal_code;
            obj.short_name = section.short_name;
            obj.street = section.street;
            sectionPresenter.View.dataGridSections.Items.Refresh();
        }
    }
}
