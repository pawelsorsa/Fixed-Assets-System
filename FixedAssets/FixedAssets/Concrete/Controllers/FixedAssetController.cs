using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class FixedAssetController : IFixedAssetService
    {
        private IFixedAssetRepository repository;

        public FixedAssetController(IFixedAssetRepository repo)
        {
            repository = repo;
        }

        public int CountFixedAssets()
        {
            return repository.FixedAssets.Count();
        }


        public object[] GetAllFixedAssets()
        {
            return repository.FixedAssets.ToArray();
        }

        public FixedAsset GetFixedAssetById(int id)
        {
            return repository.FixedAssets.FirstOrDefault(asset => asset.id == id);
        }

        public FixedAsset GetFixedAssetByInventoryNumber(string number)
        {
            return repository.FixedAssets.FirstOrDefault(asset => asset.inventory_number == number);
        }

        public object[] GetFixedAssetsByPersonId(int id)
        {
            return repository.FixedAssets.Where(asset => asset.id_person == id).ToArray();
        }

        public object[] GetFixedAssetsByActivationDate(DateTime date)
        {
            return repository.FixedAssets.Where(asset => asset.date_of_activation == date).ToArray();
        }

        public object[] GetFixedAssetsByRangeActivationDate(DateTime startDate, DateTime stopDate)
        {
            return repository.FixedAssets.Where(asset => (asset.date_of_activation >= startDate)
                && (asset.date_of_activation <= stopDate)).ToArray();
        }

        public FixedAsset GetFixedAssetBySerialNumber(string serialnumber)
        {
            return repository.FixedAssets.FirstOrDefault(asset => asset.serial_number == serialnumber);
        }

        public object[] GetFixedAssetsByMPK(string MPK)
        {
            return repository.FixedAssets.Where(asset => asset.MPK == MPK).ToArray();
        }

        public object[] GetFixedAssetsByLocalization(string localization)
        {
            return repository.FixedAssets.Where(asset => asset.localization == localization).ToArray();
        }

        public object[] GetFixedAssetsByKindId(int id)
        {
            return repository.FixedAssets.Where(asset => asset.id_kind == id).ToArray();
        }

        public object[] GetFixedAssetsBySubgroupId(int id)
        {
            return repository.FixedAssets.Where(asset => asset.id_subgroup == id).ToArray();
        }

        public object[] GetFixedAssetsByLastModifiedDate(DateTime date)
        {
            return repository.FixedAssets.Where(asset => asset.last_modified_date == date).ToArray();
        }

        public object[] GetFixedAssetsByRangeLastModifiedDate(DateTime startDate, DateTime stopDate)
        {
            return repository.FixedAssets.Where(asset => (asset.last_modified_date >= startDate)
                && (asset.last_modified_date <= stopDate)).ToArray();
        }

        public object[] GetFixedAssetsByLastModifiedId(string membershipUserLogin)
        {
            return repository.FixedAssets.Where(asset => asset.last_modifed_login == membershipUserLogin).ToArray();
        }
       
        public object[] GetFixedAssetsToCassation()
        {
            return repository.FixedAssets.Where(asset => asset.cassation == true).ToArray();
        }

        public object[] GetFixedAssetsByCreator(string membershipUserLogin)
        {
            return repository.FixedAssets.Where(asset => asset.created_by == membershipUserLogin).ToArray();
        }

        public object[] GetFixedAssetsByContractor(int contractor)
        {
            return repository.FixedAssets.Where(asset => asset.id_contractor == contractor).ToArray();
        }
    }
}
