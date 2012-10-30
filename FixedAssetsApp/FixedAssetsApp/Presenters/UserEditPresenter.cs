using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Presenters
{
    public class UserEditPresenter : PresenterBase<UserEditView>
    {
        public UserEditPresenter(UserEditView userEditView, MembershipUser user)
            : base(userEditView) 
        {
            userEditView.DataContext = user;
        }
    }
}
