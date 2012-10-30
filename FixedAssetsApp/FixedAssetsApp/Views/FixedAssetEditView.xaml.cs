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
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for FixedAssetEditView.xaml
    /// </summary>
    public partial class FixedAssetEditView : Window
    {
        public FixedAssetEditView()
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

        private void ComboBox_Id_Person_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FixedAsset asset = (FixedAsset)DataContext;
            string name = (sender as ComboBox).SelectedItem.ToString();
            string id = name.Substring(name.IndexOf("-")+2);
            id.Trim();
            int x;
            int.TryParse(id, out x);
            if (x != 0)
            {
                asset.id_person = x;
            }
        }

        private void ComboBox_Id_Kind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FixedAsset asset = (FixedAsset)DataContext;
            string name = (sender as ComboBox).SelectedItem.ToString();
            asset.id_kind = KindMethods.GetIdByNameWebServiceMethod(name);
        }

        private void ComboBox_id_subgroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FixedAsset asset = (FixedAsset)DataContext;
            string name = (sender as ComboBox).SelectedItem.ToString();
            asset.id_subgroup = SubgroupMethods.GetIdByNameWebServiceMethod(name);
        }

        private void ComboBox_casation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FixedAsset asset = (FixedAsset)DataContext;
            string name = (sender as ComboBox).SelectedItem.ToString();
            if (name == "TAK") asset.cassation = true; else asset.cassation = false;
        }

        private void checkBoxDesactivation_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            FixedAsset asset = (FixedAsset)DataContext;
            if (checkbox.IsChecked == true)
            {
                asset.date_of_desactivation = DateTime.Now;
            }
            else
            {
                asset.date_of_desactivation = null;
            }
        }
    }
}
