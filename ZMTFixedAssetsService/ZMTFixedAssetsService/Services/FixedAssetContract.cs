using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IFixedAssetService
    {
        public int CountFixedAssets()
        {
            return FixedAssetController.CountFixedAssets();
        }

        public object[] GetAllFixedAssets()
        {
            return FixedAssetController.GetAllFixedAssets();
        }

        public EF_ZMTdbEntities.FixedAsset GetFixedAssetById(int id)
        {
            return FixedAssetController.GetFixedAssetById(id);
        }

        public EF_ZMTdbEntities.FixedAsset GetFixedAssetByInventoryNumber(string number)
        {
            return FixedAssetController.GetFixedAssetByInventoryNumber(number);
        }

        public EF_ZMTdbEntities.FixedAsset GetFixedAssetBySerialNumber(string serialnumber)
        {
            return FixedAssetController.GetFixedAssetBySerialNumber(serialnumber);
        }

        public object[] GetFixedAssetsByActivationDate(DateTime date)
        {
            return FixedAssetController.GetFixedAssetsByActivationDate(date);
        }

        public object[] GetFixedAssetsByContractor(int contractor)
        {
            return FixedAssetController.GetFixedAssetsByContractor(contractor);
        }

        public object[] GetFixedAssetsByCreator(string membershipUserLogin)
        {
            return FixedAssetController.GetFixedAssetsByCreator(membershipUserLogin);
        }

        public object[] GetFixedAssetsByKindId(int id)
        {
            return FixedAssetController.GetFixedAssetsByKindId(id);
        }

        public object[] GetFixedAssetsByLastModifiedDate(DateTime date)
        {
            return FixedAssetController.GetFixedAssetsByLastModifiedDate(date);
        }

        public object[] GetFixedAssetsByLastModifiedId(string membershipUserLogin)
        {
            return FixedAssetController.GetFixedAssetsByLastModifiedId(membershipUserLogin);
        }

        public object[] GetFixedAssetsByLocalization(string localization)
        {
            return FixedAssetController.GetFixedAssetsByLocalization(localization);
        }

        public object[] GetFixedAssetsByMPK(string MPK)
        {
            return FixedAssetController.GetFixedAssetsByMPK(MPK);
        }

        public object[] GetFixedAssetsByPersonId(int id)
        {
            return FixedAssetController.GetFixedAssetsByPersonId(id);
        }

        public object[] GetFixedAssetsByRangeActivationDate(DateTime startDate, DateTime stopDate)
        {
            return FixedAssetController.GetFixedAssetsByRangeActivationDate(startDate, stopDate);
        }

        public object[] GetFixedAssetsByRangeLastModifiedDate(DateTime startDate, DateTime stopDate)
        {
            return FixedAssetController.GetFixedAssetsByRangeLastModifiedDate(startDate, stopDate);
        }

        public object[] GetFixedAssetsBySubgroupId(int id)
        {
            return FixedAssetController.GetFixedAssetsBySubgroupId(id);
        }

        public object[] GetFixedAssetsToCassation()
        {
            return FixedAssetController.GetFixedAssetsToCassation();
        }
    }
}
