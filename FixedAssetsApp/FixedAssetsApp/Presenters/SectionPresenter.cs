using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.Concrete;
using FixedAssetsApp.FixedAssetsWebService;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace FixedAssetsApp.Presenters
{
    public sealed class SectionPresenter : PresenterBase<SectionView>
    {
        private SectionMethods sectionMethods;
        public SectionPresenter(SectionView view): base(view)
        {            
            view.dataGridSections.IsReadOnly = false;
            sectionMethods = new SectionMethods();
        }


        public void GetAllSections()
        {
            ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
            list = sectionMethods.GetAllSections();

            this.View.dataGridSections.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                AddItemsSourceToDataGridList(list);
            }));
        }

        public void ClearDataGridList()
        {
            View.dataGridSections.ItemsSource = null;
            View.dataGridSections.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list)
        {
            ClearDataGridList();
            View.dataGridSections.ItemsSource = list;
            View.dataGridSections.SelectedIndex = 0;
        }

        public void GetSectionById()
        {
            try
            {
                FixedAssetsApp.FixedAssetsWebService.Section section;
                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                int id = 0;

                this.View.tbId.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (!(int.TryParse(this.View.tbId.Text, out id))) { return; }
                }));

                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    section = client.GetSectionById(id);
                }
                
                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (section == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section>();
                    list.Add(section);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSectionByName()
        {
            try
            {
                string name = string.Empty;
                this.View.tbName.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((name = this.View.tbName.Text.Trim()) == string.Empty) return;
                }));

                FixedAssetsApp.FixedAssetsWebService.Section section;
                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    section = client.GetSectionByName(name);
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (section == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section>();
                    list.Add(section);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GetSectionByShortName()
        {
            try
            {
                string short_name = string.Empty;
                this.View.tbShortName.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((short_name = this.View.tbShortName.Text.Trim()) == string.Empty) return;
                }));

                FixedAssetsApp.FixedAssetsWebService.Section section;
                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    section = client.GetSectionByShortName(short_name);
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (section == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section>();
                    list.Add(section);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GetSectionByAddress()
        {
            SectionMethods sectionMethods = new SectionMethods();
            try
            {
                string address = string.Empty;
                this.View.tbStreet.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((address = this.View.tbStreet.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    list = sectionMethods.CreateSectionList(client.GetSectionsByStreet(address));
                    client.Close();
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSectionByPostalCode()
        {
            SectionMethods sectionMethods = new SectionMethods();
            try
            {
                string postal_code = string.Empty;
                this.View.tbPostalCode.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {                
                    if ((postal_code = this.View.tbPostalCode.Text.Trim()) == string.Empty) return;
                }));
               
                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    list = sectionMethods.CreateSectionList(client.GetSectionsByPostalCode(postal_code));
                    client.Close();
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSectionByPost()
        {
            SectionMethods sectionMethods = new SectionMethods();
            try
            {
                string post = string.Empty;
                this.View.tbPost.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((post = this.View.tbPost.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    list = sectionMethods.CreateSectionList(client.GetSectionsByPost(post));
                    client.Close();
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSectionByLocacity()
        {
            SectionMethods sectionMethods = new SectionMethods();
            try
            {
                string locacity = string.Empty;
                this.View.tbLocacity.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((locacity = this.View.tbLocacity.Text.Trim()) == string.Empty) return;
                }));

                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    list = sectionMethods.CreateSectionList(client.GetSectionsByLocality(locacity));
                    client.Close();
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (list.Count == 0) { ClearDataGridList(); return; }
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSectionByPhone()
        {
            try
            {
                FixedAssetsApp.FixedAssetsWebService.Section section;
                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                int phone = 0;
                
                this.View.tbPhone.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (!(int.TryParse(this.View.tbPhone.Text, out phone))) { return; }
                }));
                
                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    section = client.GetSectionByPhoneNumber(phone.ToString());
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (section == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section>();
                    list.Add(section);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetSectionByEmail()
        {
            try
            {
                FixedAssetsApp.FixedAssetsWebService.Section section;
                ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list;
                string email = string.Empty;

                this.View.tbPhone.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if ((email = this.View.tbEmail.Text.Trim()) == string.Empty) { return; }
                }));

                using (SectionServiceClient client = new SectionServiceClient())
                {
                    client.Open();
                    section = client.GetSectionByEmail(email);
                }

                this.View.dataGridSections.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate()
                {
                    if (section == null) { ClearDataGridList(); return; }
                    list = new ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section>();
                    list.Add(section);
                    AddItemsSourceToDataGridList(list);
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void SaveSection(FixedAssetsApp.FixedAssetsWebService.Section section, bool isEdit)
        {
            using (SectionTransactionsClient client = new SectionTransactionsClient())
            {
                try
                {
                    client.Open();
                    if (isEdit)
                    {
                        client.EditSection(section);
                        MessageBox.Show("Sekcja: " + section.name + " została zaktualizowana");
                    }
                    else
                    {
                        client.AddSection(section);
                        MessageBox.Show("Sekcja: " + section.name + " została dodana");
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void DeleteSection(FixedAssetsApp.FixedAssetsWebService.Section section)
        {
            using (SectionTransactionsClient client = new SectionTransactionsClient())
            {
                try
                {
                    if (section != null)
                    {
                        client.Open();
                        client.DeleteSection(section);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridSections.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
