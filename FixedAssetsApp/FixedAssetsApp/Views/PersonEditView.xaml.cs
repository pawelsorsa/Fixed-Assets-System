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
using FixedAssetsApp.Presenters;
using FixedAssetsApp.Model;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for PersonEdit.xaml
    /// </summary>
    public partial class PersonEditView : Window
    {
        private PersonPresenter presenter;
        public PersonEditView()
        {
            InitializeComponent();
            presenter = new PersonPresenter(new PersonView());
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

        private void ComboBox_Sections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonModel ps = (PersonModel)DataContext;
            SectionMethods sm = new SectionMethods();
            ps.short_section_name = (sender as ComboBox).SelectedItem.ToString();
            ps.id_section = sm.GetIdByShortName(ps.short_section_name);
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

  
    }
}
