using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface ILicenceService
    {
        [OperationContract]
        int CountLicences();

        [OperationContract]
        object[] GetAllLicences();

        [OperationContract]
        Licence GetLicenceById(int id);

        [OperationContract]
        Licence GetLicenceByInventoryNumber(string invNumber);

        [OperationContract]
        object[] GetLicencesByFixedAssetId(int id);

        [OperationContract]
        object[] GetLicencesByLicenceNumber(string number);

        [OperationContract]
        object[] GetLicencesByName(string name);

        [OperationContract]
        object[] GetLicenceByCreator(string membershipUserLogin);

        [OperationContract]
        object[] GetLicencesByLastModifiedDate(DateTime date);

        [OperationContract]
        object[] GetLicencesByRangeLastModifiedDate(DateTime startDate, DateTime stopDate);

        [OperationContract]
        object[] GetLicencesByLastModifiedMembershipUserLogin(string membershipUserLogin);
    }
}
