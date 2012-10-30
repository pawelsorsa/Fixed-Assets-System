using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.Views;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Presenters
{
    public class PeripheralDeviceEditPresenter : PresenterBase<PeripheralDeviceEditView>
    {
        public PeripheralDeviceEditPresenter(PeripheralDeviceEditView perEditView, PeripheralDevice peripheral)
            : base(perEditView) 
        {
            perEditView.DataContext = peripheral;
        }
    }
}
