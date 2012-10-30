using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Repositories;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class PersonController : IPersonService
    {
        private IPersonRepository repository;

        public PersonController(IPersonRepository repo)
        {
            repository = repo;
        }

        public int CountPersons()
        {
            return repository.Persons.Count();
        }

        public Object[] GetAllPersons()
        {
            return repository.Persons.AsQueryable<Person>().ToArray();
        }

        public Person GetPersonById(int id)
        {
            return repository.Persons.FirstOrDefault(person => person.id == id);
        }

        public Object[] GetPersonsByName(string name)
        {
            return repository.Persons.Where(person => person.name == name).ToArray();
        }

        public Object[] GetPersonsBySurname(string suname)
        {
            return repository.Persons.Where(person => person.surname == suname).ToArray();
        }

        public Object[] GetPersonsByNameAndSurname(string name, string surname)
        {
            return repository.Persons.Where(x => (x.name == name) && (x.surname == surname)).ToArray();
        }

        public Person GetPersonByEmail(string email)
        {
            return repository.Persons.FirstOrDefault(x => x.email == email);
        }

        public Person GetPersonByPhone(int phone)
        {
            return repository.Persons.FirstOrDefault(x => x.phone_number2 == phone);
        }

        public Object[] GetPersonsWithEmail()
        {
            return repository.Persons.Where(x => x.email != null).ToArray();
        }

        public Object [] GetPersonsWithComPhone()
        {
            return repository.Persons.Where(x => x.phone_number2 != null).ToArray();
        }

        public Object [] GetPersonsBySection(int sectionId)
        {
            return repository.Persons.Where(x => x.id_section == sectionId).ToArray();
        }


    }
}
