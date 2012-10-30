using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : ILicenceService
    {
        public int CountLicences()
        {
            return LicenceController.CountLicences();
        }

        public object[] GetAllLicences()
        {
            return LicenceController.GetAllLicences();
        }

        public object[] GetLicenceByCreator(string membershipUserLogin)
        {
            return LicenceController.GetLicenceByCreator(membershipUserLogin);
        }


        public EF_ZMTdbEntities.Licence GetLicenceById(int id)
        {
            return LicenceController.GetLicenceById(id);
        }

        public EF_ZMTdbEntities.Licence GetLicenceByInventoryNumber(string invNumber)
        {
            return LicenceController.GetLicenceByInventoryNumber(invNumber);
        }

        public object[] GetLicencesByFixedAssetId(int id)
        {
            return LicenceController.GetLicencesByFixedAssetId(id);
        }

        public object[] GetLicencesByLastModifiedDate(DateTime date)
        {
            return LicenceController.GetLicencesByLastModifiedDate(date);
        }

        public object[] GetLicencesByLastModifiedMembershipUserLogin(string membershipUserLogin)
        {
            return LicenceController.GetLicencesByLastModifiedMembershipUserLogin(membershipUserLogin);
        }

        public object[] GetLicencesByLicenceNumber(string number)
        {
            return LicenceController.GetLicencesByLicenceNumber(number);
        }

        public object[] GetLicencesByName(string name)
        {
            return LicenceController.GetLicencesByName(name);
        }

        public object[] GetLicencesByRangeLastModifiedDate(DateTime startDate, DateTime stopDate)
        {
            return LicenceController.GetLicencesByRangeLastModifiedDate(startDate, stopDate);
        }
    }
}
