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
    public sealed class UserPresenter : PresenterBase<UserView>
    {

        public UserPresenter(UserView view)
            : base(view)
        {
        }

        public void ClearDataGridList()
        {
            View.dataGridUsers.ItemsSource = null;
            View.dataGridUsers.Items.Clear();
        }

        private void AddItemsSourceToDataGridList(ObservableCollection<MembershipUser> list)
        {
            ClearDataGridList();
            View.dataGridUsers.ItemsSource = list;
            View.dataGridUsers.SelectedIndex = 0;
        }

        public void GetAllUsers()
        {
            MembershipUserMethods membershipMethods = new MembershipUserMethods();
            ObservableCollection<MembershipUser> list;
            list = membershipMethods.CreateMembershipUsersList();
            
            this.View.dataGridUsers.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
            {
                AddItemsSourceToDataGridList(list);
            }));
        }

        public void SaveUser(MembershipUser user, bool isEdit)
        {
            using (MembershipUserTransactionsClient client = new MembershipUserTransactionsClient())
            {
                try
                {
                    client.Open();
                    if (isEdit)
                    {
                        client.EditMembershipUser(user);
                        MessageBox.Show("Użytkownik: " + user.login + " został zaktualizowany");
                    }
                    else
                    {
                        client.AddMembershipUser(user);
                        MessageBox.Show("Użytkownik: " + user.login + " został dodany");
                    }
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        public void DeleteUser(MembershipUser user)
        {
            using (MembershipUserTransactionsClient client = new MembershipUserTransactionsClient())
            {
                try
                {
                    MembershipUser temp = null;
                    temp = user;

                    if (temp != null)
                    {
                        client.Open();
                        client.DeleteMembershipUser(temp);
                        client.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.View.dataGridUsers.Items.Refresh();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }


    }
}
