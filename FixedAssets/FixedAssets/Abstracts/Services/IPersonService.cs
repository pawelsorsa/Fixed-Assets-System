using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        int CountPersons();

        [OperationContract]
        Object[] GetAllPersons();

        [OperationContract]
        Person GetPersonById(int id);

        [OperationContract]
        Object[] GetPersonsByName(string name);

        [OperationContract]
        Object[] GetPersonsBySurname(string surname);

        [OperationContract]
        Object[] GetPersonsByNameAndSurname(string name, string surname);

        [OperationContract]
        Person GetPersonByEmail(string email);

        [OperationContract]
        Person GetPersonByPhone(int phone);

        [OperationContract]
        Object[] GetPersonsWithEmail();

        [OperationContract]
        Object[] GetPersonsWithComPhone();

        [OperationContract]
        Object[] GetPersonsBySection(int sectionId);
    }
}
