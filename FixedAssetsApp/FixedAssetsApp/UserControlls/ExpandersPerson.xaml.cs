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
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Model;
using FixedAssetsApp.Presenters;
using FixedAssetsApp.Views;
using FixedAssetsApp.Concrete;
using System.Threading;

namespace FixedAssetsApp.UserControlls
{
    /// <summary>
    /// Interaction logic for ExpandersPerson.xaml
    /// </summary>
    /// 
    public partial class ExpandersPerson : UserControl
    {
        private delegate void GetDataDelegate();
        public ExpandersPerson()
        {
            InitializeComponent();
        }

        private void Execute(GetDataDelegate action)
        {
            ResetVisiblityDataGrid();
            Thread thread = new Thread(new ThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void btnExpanderSearchClick(object sender, RoutedEventArgs e)
        {
            PersonPresenter presenter = (PersonPresenter)this.DataContext;
            Button btn = sender as Button;

            if (btn == null) return;
            switch (btn.Name)
            {
                case "btnGetById":
                    Execute(new GetDataDelegate(presenter.GetPersonById));
                    break;
                case "btnGetByName":
                    Execute(new GetDataDelegate(presenter.GetPersonsByName));
                    break;

                case "btnGetBySurname":
                    Execute(new GetDataDelegate(presenter.GetPersonsBySurname));
                    break;

                case "btnGetByNameAndSurname":
                    Execute(new GetDataDelegate(presenter.GetPersonsByNameAndSurname));
                    break;

                case "btnGetByPhone":
                    Execute(new GetDataDelegate(presenter.GetPersonByPhone));
                    break;

                case "btnGetByEmail":
                    Execute(new GetDataDelegate(presenter.GetPersonByEmail));
                    break;

                case "btnGetBySekcja":
                    Execute(new GetDataDelegate(presenter.GetPersonsBySection));
                    break;
            }
        }

        public void btnShowPersons_Click(object sender, RoutedEventArgs e)
        {
            PersonPresenter presenter = (PersonPresenter)this.DataContext;
            Button btn = sender as Button;

            if (btn == null) return;
            switch (btn.Name)
            {
                case "showAllPersons":
                    ResetVisiblityDataGrid();
                    Execute(new GetDataDelegate(presenter.GetAllPersons));
                    presenter.View.dataGridPersons.IsReadOnly = false;
                    break;

                case "showPersonsWithPhone":
                    ResetVisiblityDataGrid();
                    Execute(new GetDataDelegate(presenter.GetPersonsWithPhone));
                    presenter.View.dataGridPersons.IsReadOnly = true;
                    presenter.View.dataGridPersons.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[3].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[4].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[6].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[7].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[8].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[9].Visibility = System.Windows.Visibility.Hidden;
                    break;

                case "showPersonsWithEmail":
                    ResetVisiblityDataGrid();
                    Execute(new GetDataDelegate(presenter.GetPersonsWithEmail));
                    presenter.View.dataGridPersons.IsReadOnly = true;
                    presenter.View.dataGridPersons.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[3].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[4].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[5].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[7].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[8].Visibility = System.Windows.Visibility.Hidden;
                    presenter.View.dataGridPersons.Columns[9].Visibility = System.Windows.Visibility.Hidden;
                    break;
            }
        }

        public void ResetVisiblityDataGrid()
        {
            PersonPresenter presenter = (PersonPresenter)this.DataContext;
            foreach (var column in presenter.View.dataGridPersons.Columns)
            {
                column.Visibility = System.Windows.Visibility.Visible;
            }
        }

    }
}
