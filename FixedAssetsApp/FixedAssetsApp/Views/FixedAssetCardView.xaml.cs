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

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for FixedAssetCard.xaml
    /// </summary>
    public partial class FixedAssetCardView : Window
    {
        public FixedAssetCardView()
        {
            InitializeComponent();
        }

        private void printButton_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            { dialog.PrintVisual(PrintPanel, "My Canvas"); }
        }
    }
}
