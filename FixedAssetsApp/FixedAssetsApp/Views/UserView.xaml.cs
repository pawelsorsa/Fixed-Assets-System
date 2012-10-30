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
using FixedAssetsApp.Concrete;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();
            DataContext = new UserPresenter(this);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserPresenter userPresenter = (UserPresenter)this.DataContext;
                MembershipUser membershipUser = new MembershipUser();
                DeepClone.CopyTo((MembershipUser)(userPresenter.View.dataGridUsers.SelectedItem), membershipUser);

                UserEditPresenter userEditPresenter = new UserEditPresenter(new UserEditView(), membershipUser);
                userEditPresenter.View.Label_AddOrEditUser.Content = "Edytowanie użytkownika";
                if (membershipUser.is_active) { userEditPresenter.View.ComboBox_active.SelectedValue = "TAK"; }
                else { userEditPresenter.View.ComboBox_active.SelectedValue = "NIE"; }
                if (userEditPresenter.View.ShowDialog() == true)
                {
                    membershipUser.creation_date = DateTime.Now;
                    userPresenter.SaveUser(membershipUser, true);
                    MembershipUser temp = (MembershipUser)userPresenter.View.dataGridUsers.SelectedItem;
                    ChangeCurrentRow(userPresenter, userEditPresenter, temp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserEditPresenter userEditPresenter = new UserEditPresenter(new UserEditView(), new MembershipUser());
                MembershipUser user = (MembershipUser)(userEditPresenter.View.DataContext);
                userEditPresenter.View.Label_AddOrEditUser.Content = "Dodawanie użytkownika";
                UserPresenter userPresenter = (UserPresenter)this.DataContext;
                if (user != null)
                {
                    userEditPresenter.View.ShowDialog();
                    if (userEditPresenter.View.DialogResult == true)
                    {
                        user.creation_date = DateTime.Now;
                        user.last_login_date = DateTime.Now;
                        user.is_active = true;
                        userPresenter.SaveUser(user, false);
                        userPresenter.GetAllUsers();
                    }
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd podczas dodawania użytkownika. Spróbuj ponownie");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridUsers_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                MessageBoxButton button = MessageBoxButton.YesNo;
                if (MessageBox.Show("Czy napewno chcesz usunąć?", "Usuwanie", button) == MessageBoxResult.Yes)
                {
                    try
                    {
                        UserPresenter userPresenter = (UserPresenter)this.DataContext;
                        var user = (MembershipUser)this.dataGridUsers.SelectedItem;
                        if (user != null)
                        {
                            userPresenter.DeleteUser((MembershipUser)user);
                            e.Handled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }


        private void btn_GetAllUsers_Click(object sender, RoutedEventArgs e)
        {
            UserPresenter userPresenter = (UserPresenter)this.DataContext;
            userPresenter.GetAllUsers();
        }


        private void ChangeCurrentRow(UserPresenter userPresenter, UserEditPresenter userEdit,
          MembershipUser obj)
        {
            MembershipUser user = ((MembershipUser)userEdit.View.DataContext);
            obj.creation_date = user.creation_date;
            obj.email = user.email;
            obj.is_active = user.is_active;
            obj.is_online = user.is_online;
            obj.last_login_date = user.last_login_date;
            obj.login = user.login;
            obj.name = user.name;
            obj.password = user.password;
            obj.PLKLogin = user.PLKLogin;
            obj.surname = user.surname;
            userPresenter.View.dataGridUsers.Items.Refresh();
        }
    }
}
