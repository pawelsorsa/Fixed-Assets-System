using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Views;
using FixedAssetsApp.Model;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using FixedAssetsApp.UserControlls;
using System.Text.RegularExpressions;
using FixedAssetsApp.Concrete;
using System.Windows.Controls;
using System.ServiceModel;
using System.Collections.ObjectModel;

namespace FixedAssetsApp.Presenters
{
    public class PersonPresenter : PresenterBase<PersonView>
    {
        public PersonPresenter(PersonView view) : base(view) 
        {
            SectionMethods sm = new SectionMethods();
            view.expanderPerson.cbSections.ItemsSource = sm.GetAllSectionsAsShortNameList();
        }

        private void EnableReadOnlyDataGrid()
        {
            View.dataGridPersons.IsReadOnly = false;
        }

        private void ClearDataGridList()
        {
            View.dataGridPersons.ItemsSource = null;
            View.dataGridPersons.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<PersonModel> list)
        {
            ClearDataGridList();
            View.dataGridPersons.ItemsSource = list;
            View.dataGridPersons.SelectedIndex = 0;
        }

        public void GetAllPersons()
        {
            try
            {
                ObservableCollection<PersonModel> list;
                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    list = PersonModel.CreatePersonSectionList(client.GetAllPersons());
                }

                this.View.dataGridPersons.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) return;
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonById()
        {
            try
            {
                Person person;
                ObservableCollection<PersonModel> list;
                int id = 0;

                this.View.expanderPerson.tbId.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (!(int.TryParse(this.View.expanderPerson.tbId.Text, out id))) { return; }
                }));

                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    person = client.GetPersonById(id);
                }

                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (person == null) { ClearDataGridList(); return; }
                    ClearDataGridList();
                    EnableReadOnlyDataGrid();
                    list = new ObservableCollection<PersonModel>();
                    list.Add(PersonModel.CreatePersonSection(person));
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonsByName()
        {
            try
            {
                string name = string.Empty;
                this.View.expanderPerson.tbName.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if((name = this.View.expanderPerson.tbName.Text.Trim()) == string.Empty) return;
                }));
                
                ObservableCollection<PersonModel> list;
                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    list = PersonModel.CreatePersonSectionList(client.GetPersonsByName(name));
                }

                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    EnableReadOnlyDataGrid();
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonsBySurname()
        {
            try
            {
                string surname = string.Empty;
                this.View.expanderPerson.tbSurname.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((surname = this.View.expanderPerson.tbSurname.Text.Trim()) == string.Empty) return;
                }));
                
                ObservableCollection<PersonModel> list;
                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    list = PersonModel.CreatePersonSectionList(client.GetPersonsBySurname(surname));   
                }

                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    EnableReadOnlyDataGrid();
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GetPersonsByNameAndSurname()
        {
            try
            {
                string nameAndSurname = string.Empty;

                this.View.expanderPerson.tbName_Surname.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((nameAndSurname = this.View.expanderPerson.tbName_Surname.Text.Trim()) == string.Empty) return;
                }));

                string[] tab = Regex.Split(nameAndSurname, " ");
                ObservableCollection<PersonModel> list;
                

                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    using (PersonServiceClient client = new PersonServiceClient())
                    {
                        client.Open();
                        list = PersonModel.CreatePersonSectionList(client.GetPersonsByNameAndSurname(tab[0].Trim(), tab[1].Trim()));
                        if (list.Count == 0) { ClearDataGridList(); return; }
                        EnableReadOnlyDataGrid();
                        AddItemsSourceToDataGridList(list);
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonByPhone()
        {
            try
            {
                int phone = 0;
                this.View.expanderPerson.tbPhone.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (!int.TryParse(this.View.expanderPerson.tbPhone.Text, out phone)) return; ;
                }));
                
                Person person;
                ObservableCollection<PersonModel> list;

                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    person = client.GetPersonByPhone(phone); 
                }
                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (person == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<PersonModel>();
                    list.Add(PersonModel.CreatePersonSection(person));
                    EnableReadOnlyDataGrid();
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonByEmail()
        {
            try
            {
                string email = string.Empty;
                this.View.expanderPerson.tbEmail.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((email = this.View.expanderPerson.tbEmail.Text.Trim())== string.Empty) return; ;
                }));

                Person person;
                ObservableCollection<PersonModel> list;
                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    person = client.GetPersonByEmail(email);
                }
                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (person == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<PersonModel>();
                    list.Add(PersonModel.CreatePersonSection(person));
                    EnableReadOnlyDataGrid();
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonsBySection()
        {
            try
            {
                string section = string.Empty;
                this.View.expanderPerson.cbSections.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((section = this.View.expanderPerson.cbSections.SelectedValue.ToString().Trim()) == string.Empty) return; ;
                }));

                ObservableCollection<PersonModel> list;
                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    SectionMethods sm = new SectionMethods();
                    int id = sm.GetIdByShortName(section);
                    list = PersonModel.CreatePersonSectionList(client.GetPersonsBySection(id));
                }

                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    EnableReadOnlyDataGrid();
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonsWithPhone()
        {
            try
            {
                ObservableCollection<PersonModel> list;
                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    list = PersonModel.CreatePersonSectionList(client.GetPersonsWithComPhone());
                    if (list.Count == 0) { ClearDataGridList(); return; }
                }

                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    EnableReadOnlyDataGrid();
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetPersonsWithEmail()
        {
            try
            {
                ObservableCollection<PersonModel> list;
                using (PersonServiceClient client = new PersonServiceClient())
                {
                    client.Open();
                    list = PersonModel.CreatePersonSectionList(client.GetPersonsWithEmail());
                    if (list.Count == 0) { ClearDataGridList(); return; }
                }

                this.View.dataGridPersons.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    EnableReadOnlyDataGrid();
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void SavePerson(PersonModel ps, bool isEdit)
        {
            using (PersonTransactionsClient client = new PersonTransactionsClient())
            {
                try
                {
                    Person person = null;
                    person = PersonModel.CreatePerson(ps);

                    if (person != null)
                    {
                        client.Open();
                        if (isEdit)
                        {
                            client.EditPerson(person);
                            MessageBox.Show("Pracownik: " + person.name + " " + person.surname + " został zaktualizowany");
                        }
                        else
                        {
                            client.AddPerson(person);
                            MessageBox.Show("Pracownik: " + person.name + " " + person.surname + " został dodany");
                            this.GetAllPersons();
                        }
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }          
        }

        public void DeletePerson(PersonModel ps)
        {
            using (PersonTransactionsClient client = new PersonTransactionsClient())
            {
                try
                {
                    Person person = null;
                    person = PersonModel.CreatePerson(ps);

                    if (person != null)
                    {
                        client.Open();
                        client.DeletePerson(person);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridPersons.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }       
        }
    }
}
