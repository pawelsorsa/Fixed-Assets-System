using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : ISectionService
    {
        public int CountSections()
        {
            return SectionController.CountSections();
        }

        public object[] GetAllSections()
        {
            return SectionController.GetAllSections();
        }

        public EF_ZMTdbEntities.Section GetSectionByEmail(string email)
        {
            return SectionController.GetSectionByEmail(email);
        }

        public EF_ZMTdbEntities.Section GetSectionById(int id)
        {
            return SectionController.GetSectionById(id);
        }

        public EF_ZMTdbEntities.Section GetSectionByName(string name)
        {
            return SectionController.GetSectionByName(name);
        }

        public EF_ZMTdbEntities.Section GetSectionByPhoneNumber(string phone)
        {
            return SectionController.GetSectionByPhoneNumber(phone);
        }

        public EF_ZMTdbEntities.Section GetSectionByShortName(string shortname)
        {
            return SectionController.GetSectionByShortName(shortname);
        }

        public object[] GetSectionsByLocality(string locality)
        {
            return SectionController.GetSectionsByLocality(locality);
        }

        public object[] GetSectionsByPost(string post)
        {
            return SectionController.GetSectionsByPost(post);
        }

        public object[] GetSectionsByPostalCode(string postalcode)
        {
            return SectionController.GetSectionsByPostalCode(postalcode);
        }

        public object[] GetSectionsByStreet(string street)
        {
            return SectionController.GetSectionsByStreet(street);
        }
    }
}
