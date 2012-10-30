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
using System.Windows.Threading;
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.UserControlls;
using FixedAssetsApp.Model;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        public PersonView()
        {
            try
            {
                InitializeComponent();
                DataContext = new PersonPresenter(this);    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private delegate void GetDataDelegate();
        private void ExecuteThread(GetDataDelegate action)
        {
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void dataGridPersons_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        PersonPresenter personPresenter = new PersonPresenter(this);
                        PersonModel ps = (PersonModel)this.dataGridPersons.SelectedItem;

                        if (ps != null)
                        {
                            personPresenter.DeletePerson(ps);
                            e.Handled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void btnUpdatePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonPresenter personPresenter = new PersonPresenter(this);
                PersonModel ps = (PersonModel)((PersonModel)personPresenter.View.dataGridPersons.SelectedItem).Clone();
                PersonEditPresenter personEditPresenter = new PersonEditPresenter(new PersonEditView(), ps);
                personEditPresenter.View.ComboBox_Sections.SelectedItem = ps.short_section_name;
                personEditPresenter.View.AddOrEditPerson.Content = "Edytowanie pracownika";
                personEditPresenter.View.ShowDialog();
                if (personEditPresenter.View.DialogResult == true)
                {
                    if (ps != null)
                    {
                        personPresenter.SavePerson(ps, true);
                        ChangeCurrentRow(personPresenter, personEditPresenter, (PersonModel)personPresenter.View.dataGridPersons.SelectedItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreatePerson_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonPresenter personPresenter = new PersonPresenter(this);
                PersonEditPresenter personEditPresenter = new PersonEditPresenter(new PersonEditView(), new PersonModel());
                PersonModel ps = (PersonModel)(personEditPresenter.View.DataContext);
                personEditPresenter.View.AddOrEditPerson.Content = "Dodawanie nowego pracownika";
                personEditPresenter.View.ShowDialog();
                if (ps != null)
                {
                    if (personEditPresenter.View.DialogResult == true)
                    {
                        personPresenter.SavePerson((PersonModel)ps, false);
                        e.Handled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ChangeCurrentRow(PersonPresenter presenterPerson,PersonEditPresenter presenterEdit, PersonModel obj)
        {
            SectionMethods sm = new SectionMethods(); 
            PersonModel ps = ((PersonModel)presenterEdit.View.DataContext);
            obj.area_code = ps.area_code;
            obj.id_section = ps.id_section;
            obj.name = ps.name;
            obj.phone_number = ps.phone_number;
            obj.phone_number2 = ps.phone_number2;
            obj.short_section_name = sm.GetShortNameById(ps.id_section);
            obj.surname = ps.surname;
            obj.email = ps.email;
            presenterPerson.View.dataGridPersons.Items.Refresh();
        }
        
    }
}
