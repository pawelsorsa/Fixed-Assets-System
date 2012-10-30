using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Presenters
{
    public class LicenceEditPresenter : PresenterBase<LicenceEditView>
    {
        public LicenceEditPresenter(LicenceEditView licenceEditView, Licence licence)
            : base(licenceEditView) 
        {
            licenceEditView.DataContext = licence;
        }
    }
}
