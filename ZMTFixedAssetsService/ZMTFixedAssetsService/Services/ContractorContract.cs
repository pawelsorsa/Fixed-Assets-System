using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IContractorService
    {
        public int CountContractors()
        {
            return ContractorController.CountContractors();
        }

        public object[] GetAllContractors()
        {
            return ContractorController.GetAllContractors();
        }

        public EF_ZMTdbEntities.Contractor GetContractorByAccountNumber(string number)
        {
            return ContractorController.GetContractorByAccountNumber(number);
        }

        public EF_ZMTdbEntities.Contractor GetContractorById(int id)
        {
            return ContractorController.GetContractorById(id);
        }

        public EF_ZMTdbEntities.Contractor GetContractorByNip(int nip)
        {
            return ContractorController.GetContractorByNip(nip);
        }

        public object[] GetContractorsByCity(string locacity)
        {
            return ContractorController.GetContractorsByCity(locacity);
        }

        public object[] GetContractorsByCountry(string country)
        {
            return ContractorController.GetContractorsByCountry(country);
        }

        public object[] GetContractorsByName(string name)
        {
            return ContractorController.GetContractorsByName(name);
        }

        public object[] GetContractorsByPostalCode(string postalCode)
        {
            return ContractorController.GetContractorsByPostalCode(postalCode);
        }

        public object[] GetContractorsByStreet(string street)
        {
            return ContractorController.GetContractorsByStreet(street);
        }
    }
}
