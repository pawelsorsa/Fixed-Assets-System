using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;

namespace FixedAssetsApp.Concrete
{
    public sealed class KindMethods
    {
        private ObservableCollection<Kind> kinds = new ObservableCollection<Kind>();
        public KindMethods()
        {
            GetAllKinds();
        }

        public void GetAllKinds()
        {
            using (FixedAssetsWebService.KindServiceClient Client = new FixedAssetsWebService.KindServiceClient())
            {
                Client.Open();
                object[] list = Client.GetAllKinds();
                foreach (Kind kind in list)
                {
                    kinds.Add(kind);
                }
            }
        }

        public ObservableCollection<Kind> CreateKindsList()
        {
            return kinds;
        }

        public string GetNameById(int id)
        {
            Kind kind = kinds.FirstOrDefault(x => x.id == id);
            if (kind != null)
            {
                return kind.name;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetNameByIdWebServiceMethod(int id)
        {
            string name = string.Empty;
            using (FixedAssetsWebService.KindServiceClient Client = new FixedAssetsWebService.KindServiceClient())
            {
                Client.Open();
                Kind kind = Client.GetKindById(id);
                if (kind != null)
                {
                    return kind.name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static int GetIdByNameWebServiceMethod(string name)
        {

            using (FixedAssetsWebService.KindServiceClient Client = new FixedAssetsWebService.KindServiceClient())
            {
                Client.Open();
                Kind kind = Client.GetKindByName(name);
                if (kind != null)
                {
                    return kind.id;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string[] GetAllKindsAsStringArray()
        {
            string[] array = kinds.Select(x => x.name).Distinct().ToArray<string>();
            return array;
        }


    }
}
