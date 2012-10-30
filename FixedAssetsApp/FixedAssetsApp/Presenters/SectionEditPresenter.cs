using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;

namespace FixedAssetsApp.Presenters
{
    public class SectionEditPresenter : PresenterBase<SectionEditView>
    {
        public SectionEditPresenter(SectionEditView sectionEditView, FixedAssetsApp.FixedAssetsWebService.Section section)
        : base(sectionEditView) 
        {
            sectionEditView.DataContext = section;
        }
    }
}
