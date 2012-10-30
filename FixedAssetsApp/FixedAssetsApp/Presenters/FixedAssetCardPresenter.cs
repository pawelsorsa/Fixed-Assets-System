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
using System.Globalization;
using System.Text.RegularExpressions;

namespace FixedAssetsApp.Presenters
{
    public sealed class FixedAssetCardPresenter : PresenterBase<FixedAssetCardView>
    {
        public FixedAssetCardPresenter(FixedAssetCardView view, FixedAsset asset)
            :base(view)
        {
            InitializeCard(view, asset);
            InitializeCardLicences(view, asset);
            InitializeCardDevices(view, asset);
        }

        public void InitializeCard(FixedAssetCardView view, FixedAsset asset)
        {
            view.label_FixedAssetID.Content = asset.id.ToString();
            view.label_InventoryNumber.Content = asset.inventory_number.ToString();
            view.label_Owner.Content = PersonMethods.GetNameAndSurnameByIdWebServiceMethod((int)asset.id_person);
            view.label_DateOfActivation.Content = asset.date_of_activation.ToString();
            view.label_DateOfDesactivation.Content = asset.date_of_desactivation.ToString();
            view.label_Cassation.Content = asset.cassation ? "TAK" : "NIE";
            //view.label_Comment.Content = asset.comment.ToString();
            view.label_Kind.Content = asset.id_kind.ToString();
            view.label_Localization.Content = asset.localization.ToString();
            view.label_MPK.Content = asset.MPK.ToString();
            view.label_Quantity.Content = asset.quantity.ToString();
            view.label_SerialNumber.Content = asset.serial_number.ToString();
            view.label_Subgroup.Content = SubgroupMethods.GetNameByIdWebServiceMethod((int)asset.id_subgroup, true);
        }

        public void InitializeCardLicences(FixedAssetCardView view, FixedAsset asset)
        {
            view.DataGridLicences.ItemsSource = LicenceMethods.GetLicencesByFixedAssetId((int)asset.id);
        }

        public void InitializeCardDevices(FixedAssetCardView view, FixedAsset asset)
        {
            object [] list = DeviceMethods.GetDevicesByFixedAssetId((int)asset.id);
            view.DataGridDevices.ItemsSource = DeviceMethods.CreateDevicesList(list);
        }
    }
}
