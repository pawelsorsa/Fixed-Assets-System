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
using FixedAssetsApp.Model;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for DeviceEditView.xaml
    /// </summary>
    public partial class DeviceEditView : Window
    {
        public DeviceEditView()
        {
            InitializeComponent();
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

        private void ComboBox_Devies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeviceModel dev = (DeviceModel)DataContext;
            dev.name_peripheral_device = (sender as ComboBox).SelectedItem.ToString();
            dev.id_peripheral_device = PeripheralDeviceMethods.GetIdByNameWebServiceMethod(dev.name_peripheral_device);
        }

    }
}
