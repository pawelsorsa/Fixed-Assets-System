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
using FixedAssetsApp.Views;
using System.Threading;

namespace FixedAssetsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate void GetDataDelegate();
        private MembershipUserPresenter membershipUserPresenter;
        public MainWindow()
        {
            InitializeComponent();
            membershipUserPresenter = new MembershipUserPresenter();
            this.DataContext = membershipUserPresenter;
            this.logout_menu.Visibility = System.Windows.Visibility.Collapsed;
        }

        public void NavigateMenuLogged(bool islogged)
        {
            if (islogged)
            {
                this.log_menu.Visibility = System.Windows.Visibility.Collapsed;
                this.logout_menu.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.log_menu.Visibility = System.Windows.Visibility.Visible;
                this.logout_menu.Visibility = System.Windows.Visibility.Collapsed;
            }

            this.tb_Login.Text = "";
            this.tb_Password.Password = "";
        }

        private void btnPersons_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new PersonPresenter(new PersonView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnSections_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new SectionPresenter(new SectionView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnDevices_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new DevicePresenter(new DeviceView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnPeripheral_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
               MainContent.Content = (new PeripheralDevicePresenter(new PeripheralDeviceView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnSubgroup_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new SubgroupPresenter(new SubgroupView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnKinds_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new KindPresenter(new KindView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnLicences_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new LicencePresenter(new LicenceView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnFixedAssets_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new FixedAssetPresenter(new FixedAssetView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.IsAuthorized)
            {
                MainContent.Content = (new UserPresenter(new UserView())).View;
            }
            else
            {
                MainContent.Content = (new AuthenticationPresenter(new AuthenticationView())).View;
            }
        }

        private void btnLogon_Click(object sender, RoutedEventArgs e)
        {
            if (membershipUserPresenter.LogOn(this.tb_Login.Text, this.tb_Password.Password))
            {
                MainContent.Content = (new LoginInfoPresenter(new LoginInfoView(), 0)).View;
                NavigateMenuLogged(true);
                TextBlock_LoggedAs.Text = "Jesteś zalogowany jako: " + membershipUserPresenter.CurrentUser.login + "  ";
            }
            else
            {
                if (membershipUserPresenter.IsActive == false)
                {
                    MainContent.Content = (new LoginInfoPresenter(new LoginInfoView(), 3)).View;
                }
                else
                {
                    MainContent.Content = (new LoginInfoPresenter(new LoginInfoView(), 1)).View;
                }
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            membershipUserPresenter.LogOut();
            MainContent.Content = (new LoginInfoPresenter(new LoginInfoView(), 2)).View;
            NavigateMenuLogged(false);
        }

        

    }
}
