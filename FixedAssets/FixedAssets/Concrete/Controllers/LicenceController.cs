using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class LicenceController : ILicenceService
    {
        private ILicenceRepository repository;

        public LicenceController(ILicenceRepository repo)
        {
            repository = repo;
        }

        public int CountLicences()
        {
            return repository.Licences.Count();
        }

        public object[] GetAllLicences()
        {
            return repository.Licences.ToArray();
        }

        public Licence GetLicenceById(int id)
        {
            return repository.Licences.FirstOrDefault(licence => licence.id_number == id);
        }

        public Licence GetLicenceByInventoryNumber(string invNumber)
        {
            return repository.Licences.FirstOrDefault(licence => licence.inventory_number == invNumber);
        }

        public object[] GetLicencesByFixedAssetId(int id)
        {
            return repository.Licences.Where(licence => licence.assign_fixed_asset == id).ToArray();
        }

        public object[] GetLicencesByLicenceNumber(string number)
        {
            return repository.Licences.Where(licence => licence.licence_number == number).ToArray();
        }

        public object[] GetLicencesByName(string name)
        {
            return repository.Licences.Where(licence => licence.name == name).ToArray();
        }

        public object[] GetLicenceByCreator(string membershipUserLogin)
        {
            return repository.Licences.Where(licence => licence.created_by == membershipUserLogin).ToArray();
        }

        public object[] GetLicencesByLastModifiedDate(DateTime date)
        {
            return repository.Licences.Where(licence => licence.last_modified_date == date).ToArray();
        }

        public object[] GetLicencesByRangeLastModifiedDate(DateTime starDate, DateTime stopDate)
        {
            return repository.Licences.Where(licence => (licence.last_modified_date >= starDate)
                && (licence.last_modified_date <= stopDate)).ToArray();
        }

        public object[] GetLicencesByLastModifiedMembershipUserLogin(string membershipUserLogin)
        {
            return repository.Licences.Where(licence => licence.last_modified_login == membershipUserLogin).ToArray();
        }

    }
}
