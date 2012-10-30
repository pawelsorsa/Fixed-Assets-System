using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface ISectionService
    {
        [OperationContract]
        int CountSections();

        [OperationContract]
        object[] GetAllSections();

        [OperationContract]
        Section GetSectionById(int id);

        [OperationContract]
        Section GetSectionByName(string name);

        [OperationContract]
        Section GetSectionByShortName(string shortname);

        [OperationContract]
        object[] GetSectionsByPostalCode(string postalcode);

        [OperationContract]
        object[] GetSectionsByPost(string post);

        [OperationContract]
        object[] GetSectionsByLocality(string locality);

        [OperationContract]
        Section GetSectionByPhoneNumber(string phone);

        [OperationContract]
        Section GetSectionByEmail(string email);

        [OperationContract]
        object[] GetSectionsByStreet(string street);
    }
}
