using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Concrete
{
    public class FixedAssetMethods
    {
        private ObservableCollection<FixedAsset> fixedAssets = new ObservableCollection<FixedAsset>();
        public FixedAssetMethods()
        {
            GetAllFixedAssets();
        }

        public void GetAllFixedAssets()
        {
            using (FixedAssetsWebService.FixedAssetServiceClient Client = new FixedAssetsWebService.FixedAssetServiceClient())
            {
                Client.Open();
                object[] list = Client.GetAllFixedAssets();
                foreach (FixedAsset fa in list)
                {
                    fixedAssets.Add(fa);
                }
            }
        }

        public ObservableCollection<FixedAsset> CreateFixedAssetList(object[] table)
        {
            FixedAssetMethods sm = new FixedAssetMethods();
            ObservableCollection<FixedAsset> list = new ObservableCollection<FixedAsset>();

            foreach (FixedAsset asset in table)
            {
                list.Add(asset);
            }
            return list;
        }

        public ObservableCollection<FixedAsset> CreateFixedAssetList()
        {
            return fixedAssets;
        }
    }
}
