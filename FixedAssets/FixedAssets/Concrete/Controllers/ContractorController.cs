using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class ContractorController : IContractorService
    {
        private IContractorRepository repository;
        public ContractorController(IContractorRepository repo)
        {
            repository = repo;
        }

        public int CountContractors()
        {
            return repository.Contractors.Count();
        }

        public Object[] GetAllContractors()
        {
            return repository.Contractors.ToArray();
        }

        public Contractor GetContractorById(int id)
        {
            return repository.Contractors.FirstOrDefault(contractor => contractor.id == id);
        }

        public Contractor GetContractorByNip(int nip)
        {
            return repository.Contractors.FirstOrDefault(contracotor => contracotor.nip == nip);
        }

        public Object [] GetContractorsByName(string name)
        {
            return repository.Contractors.Where(contractor => contractor.name == name).ToArray();
        }

        public Contractor GetContractorByAccountNumber(string number)
        {
            return repository.Contractors.FirstOrDefault(contractor => contractor.account_number == number);
        }

        public Object[] GetContractorsByStreet(string street)
        {
            return repository.Contractors.Where(contractor => contractor.street == street).ToArray();
        }

        public Object[] GetContractorsByCity(string locacity)
        {
            return repository.Contractors.Where(contractor => contractor.city == locacity).ToArray();
        }

        public Object[] GetContractorsByCountry(string country)
        {
            return repository.Contractors.Where(contractor => contractor.country == country).ToArray();
        }

        public Object[] GetContractorsByPostalCode(string postalCode)
        {
            return repository.Contractors.Where(contractor => contractor.postal_code == postalCode).ToArray();
        }
    }
}
