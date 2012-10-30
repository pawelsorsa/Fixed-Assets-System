using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using FixedAssetsApp.FixedAssetsWebService;
using System.Windows.Forms;

namespace FixedAssetsApp.Concrete
{
    public class SectionMethods
    {
        private ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> sections = new ObservableCollection<FixedAssetsWebService.Section>();

        public SectionMethods()
        {
            GetSections();
        }

        public ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> CreateSectionList(object[] table)
        {
            SectionMethods sm = new SectionMethods();
            ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> list = new ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section>();

            foreach (FixedAssetsApp.FixedAssetsWebService.Section section in table)
            {
                list.Add(section);
            }
            return list;
        }


        private void GetSections()
        {
            try
            {
                using (FixedAssetsWebService.SectionServiceClient sectionClient = new FixedAssetsWebService.SectionServiceClient())
                {
                    sectionClient.Open();
                    object[] list = sectionClient.GetAllSections();
                    foreach (FixedAssetsWebService.Section section in list)
                    {
                        sections.Add(section);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public FixedAssetsApp.FixedAssetsWebService.Section CloneSection(FixedAssetsApp.FixedAssetsWebService.Section section)
        {
            FixedAssetsApp.FixedAssetsWebService.Section temp = new FixedAssetsWebService.Section();
            temp.email = section.email;
            temp.id = section.id;
            temp.locality = section.locality;
            temp.name = section.name;
            temp.phone_number = section.phone_number;
            temp.post = section.post;
            temp.postal_code = section.postal_code;
            temp.short_name = section.short_name;
            temp.street = section.street;
            return temp;
        }

        public ObservableCollection<FixedAssetsApp.FixedAssetsWebService.Section> GetAllSections()
        {
            return sections;
        }

        public string GetShortNameById(int id)
        {
            FixedAssetsWebService.Section section = sections.FirstOrDefault(x => x.id == id);
            if (section != null)
            {
                return section.short_name;
            }
            else
            {
                return string.Empty;
            }
        }

        public int GetIdByShortName(string name)
        {
            FixedAssetsWebService.Section section = sections.FirstOrDefault(x => x.short_name == name);
            if (section != null)
            {
                return section.id;
            }
            else
            {
                return 0;
            }
        }

        public string[] GetAllSectionsAsShortNameArray()
        {
            string[] array = sections.Select(x => x.short_name).Distinct().ToArray<string>();
            return array;
        }

        public List<string> GetAllSectionsAsShortNameList()
        {
            return sections.Select(x => x.short_name).Distinct().ToList();
        }
    }
}
