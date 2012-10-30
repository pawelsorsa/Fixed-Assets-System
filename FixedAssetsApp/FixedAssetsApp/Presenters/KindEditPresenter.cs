using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Presenters
{
    public class KindEditPresenter : PresenterBase<KindEditView>
    {
        public KindEditPresenter(KindEditView kindEditView, Kind kind)
            : base(kindEditView) 
        {
            kindEditView.DataContext = kind;
        }
    }
}
