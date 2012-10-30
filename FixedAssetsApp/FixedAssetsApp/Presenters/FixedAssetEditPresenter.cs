using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Presenters
{
    public class FixedAssetEditPresenter : PresenterBase<FixedAssetEditView>
    {
        public FixedAssetEditPresenter(FixedAssetEditView fixedAssetEditView, FixedAsset fixedAsset)
            : base(fixedAssetEditView) 
        {
            fixedAssetEditView.DataContext = fixedAsset;
        }
    }
}
