using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Presenters
{
    public class SubgroupEditPresenter : PresenterBase<SubgroupEditView>
    {
        public SubgroupEditPresenter(SubgroupEditView subgroupEditView, Subgroup subgroup)
        : base(subgroupEditView) 
        {
            subgroupEditView.DataContext = subgroup;
        }
    }
}
