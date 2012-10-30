using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IContractorService
    {
        [OperationContract]
        int CountContractors();

        [OperationContract]
        Object[] GetAllContractors();

        [OperationContract]
        Contractor GetContractorById(int id);

        [OperationContract]
        Contractor GetContractorByNip(int nip);

        [OperationContract]
        Object[] GetContractorsByName(string name);

        [OperationContract]
        Contractor GetContractorByAccountNumber(string number);

        [OperationContract]
        Object[] GetContractorsByStreet(string street);

        [OperationContract]
        Object[] GetContractorsByCity(string locacity);

        [OperationContract]
        Object[] GetContractorsByCountry(string country);

        [OperationContract]
        Object[] GetContractorsByPostalCode(string postalCode);
    }
}
