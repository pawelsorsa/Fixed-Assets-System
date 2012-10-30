using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssetsApp.FixedAssetsWebService;
using System.Collections.ObjectModel;

namespace FixedAssetsApp.Concrete
{
    public sealed class SubgroupMethods
    {
        private ObservableCollection<Subgroup> subgroups = new ObservableCollection<Subgroup>();

        public SubgroupMethods()
        {
            GetAllSubgroups();
        }

        public void GetAllSubgroups()
        {
            using (FixedAssetsWebService.SubgroupServiceClient Client = new FixedAssetsWebService.SubgroupServiceClient())
            {
                Client.Open();
                object[] list = Client.GetAllSubgroups();
                foreach (Subgroup s in list)
                {
                    subgroups.Add(s);
                }
            }
        }

        public ObservableCollection<Subgroup> CreateSubgroupsList()
        {
            return subgroups;
        }

        public string GetNameById(int id)
        {
            Subgroup subgroup = subgroups.FirstOrDefault(x => x.id == id);
            if (subgroup != null)
            {
                return subgroup.name;
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetNameByIdWebServiceMethod(int id, bool isShortName)
        {
            string name = string.Empty;
            using (FixedAssetsWebService.SubgroupServiceClient Client = new FixedAssetsWebService.SubgroupServiceClient())
            {
                Client.Open();
                Subgroup subgroup = Client.GetSubgroupById(id);
                if (subgroup != null)
                {
                    if (isShortName)
                    {
                        return subgroup.short_name;
                    }
                    else
                    {
                        return subgroup.name;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static int GetIdByNameWebServiceMethod(string name)
        {
            using (FixedAssetsWebService.SubgroupServiceClient Client = new FixedAssetsWebService.SubgroupServiceClient())
            {
                Client.Open();
                Subgroup subgroup = Client.GetSubgroupByName(name);
                if (subgroup != null)
                {
                    return subgroup.id;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string[] GetAllSubgroupsAsStringArray()
        {
            string[] array = subgroups.Select(x => x.name).Distinct().ToArray<string>();
            return array;
        }

    }
}
