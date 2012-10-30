using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;
using FixedAssetsApp.Concrete;
using System.Windows.Threading;
using System.Windows.Forms;

namespace FixedAssetsApp.Presenters
{
    public sealed class LoginInfoPresenter : PresenterBase<LoginInfoView>
    {
        public LoginInfoPresenter(LoginInfoView view, int isLogged)
            : base(view)
        {
            if (isLogged == 0)
            {
                this.View.textBlock_login_info.Text = "Zostałeś poprawnie zalogowany";
            }
            else if (isLogged == 1)
            {
                this.View.textBlock_login_info.Text = "Podany login lub hasło nie zgadza się. Spróbuj ponownie.";
            }
            else if(isLogged == 2)
            {
                this.View.textBlock_login_info.Text = "Zostałeś wylogowany";
            }
            else if (isLogged == 3)
            {
                this.View.textBlock_login_info.Text = "Podany użytkownik jest nieaktywny";
            }
        }
    }
}
