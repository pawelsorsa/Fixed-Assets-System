using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Concrete
{
    public sealed class LicenceMethods
    {
        private ObservableCollection<Licence> licences = new ObservableCollection<Licence>();
        public LicenceMethods()
        {
            GetAllLicences();
        }

        public void GetAllLicences()
        {
            using (FixedAssetsWebService.LicenceServiceClient Client = new FixedAssetsWebService.LicenceServiceClient())
            {
                Client.Open();
                object[] list = Client.GetAllLicences();
                foreach (Licence dev in list)
                {
                    licences.Add(dev);
                }
            }
        }

        public ObservableCollection<Licence> CreateLicencesList()
        {
            return licences;
        }

        public static ObservableCollection<Licence> GetLicencesByFixedAssetId(int id)
        {
            object[] list;
            ObservableCollection<Licence> licenceList = new ObservableCollection<Licence>();
            using (LicenceServiceClient client = new LicenceServiceClient())
            {
                client.Open();
                list = client.GetLicencesByFixedAssetId(id);
                client.Close();
            }

            foreach (Licence lic in list)
            {
                licenceList.Add(lic);
            }
            return licenceList;
        }
    }
}
