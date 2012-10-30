using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IPersonService
    {
        public int CountPersons()
        {
            return PersonController.CountPersons();
        }

        public object[] GetAllPersons()
        {
            return PersonController.GetAllPersons();
        }

        public EF_ZMTdbEntities.Person GetPersonByEmail(string email)
        {
            return PersonController.GetPersonByEmail(email);
        }

        public EF_ZMTdbEntities.Person GetPersonById(int id)
        {
            return PersonController.GetPersonById(id);
        }

        public EF_ZMTdbEntities.Person GetPersonByPhone(int phone)
        {
            return PersonController.GetPersonByPhone(phone);
        }

        public object[] GetPersonsByName(string name)
        {
            return PersonController.GetPersonsByName(name);
        }

        public object[] GetPersonsByNameAndSurname(string name, string surname)
        {
            return PersonController.GetPersonsByNameAndSurname(name, surname);
        }

        public object[] GetPersonsBySection(int sectionId)
        {
            return PersonController.GetPersonsBySection(sectionId);
        }

        public object[] GetPersonsBySurname(string surname)
        {
            return PersonController.GetPersonsBySurname(surname);
        }

        public object[] GetPersonsWithComPhone()
        {
            return PersonController.GetPersonsWithComPhone();
        }

        public object[] GetPersonsWithEmail()
        {
            return PersonController.GetPersonsWithEmail();
        }
    }
}
