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
using System.Windows.Shapes;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for UserEditView.xaml
    /// </summary>
    public partial class UserEditView : Window
    {
        public UserEditView()
        {
            InitializeComponent();
            this.ComboBox_active.ItemsSource = new List<string> { "TAK", "NIE" };
        }

        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void ComboBox_casation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MembershipUser user = (MembershipUser)DataContext;
            string name = (sender as ComboBox).SelectedItem.ToString();
            if (name == "TAK") user.is_active = true; else user.is_active = false;
        }
    }
}
