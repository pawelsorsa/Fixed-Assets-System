using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IFixedAssetService
    {
        [OperationContract]
        int CountFixedAssets();

        [OperationContract]
        object[] GetAllFixedAssets();

        [OperationContract]
        FixedAsset GetFixedAssetById(int id);

        [OperationContract]
        FixedAsset GetFixedAssetByInventoryNumber(string number);

        [OperationContract]
        object[] GetFixedAssetsByPersonId(int id);

        [OperationContract]
        object[] GetFixedAssetsByActivationDate(DateTime date);

        [OperationContract]
        object[] GetFixedAssetsByRangeActivationDate(DateTime startDate, DateTime stopDate);

        [OperationContract]
        FixedAsset GetFixedAssetBySerialNumber(string serialnumber);

        [OperationContract]
        object[] GetFixedAssetsByMPK(string MPK);

        [OperationContract]
        object[] GetFixedAssetsByLocalization(string localization);

        [OperationContract]
        object[] GetFixedAssetsByKindId(int id);

        [OperationContract]
        object[] GetFixedAssetsBySubgroupId(int id);

        [OperationContract]
        object[] GetFixedAssetsByLastModifiedDate(DateTime date);

        [OperationContract]
        object[] GetFixedAssetsByRangeLastModifiedDate(DateTime startDate, DateTime stopDate);

        [OperationContract]
        object[] GetFixedAssetsByLastModifiedId(string membershipUserLogin);

        [OperationContract]
        object[] GetFixedAssetsToCassation();

        [OperationContract]
        object[] GetFixedAssetsByCreator(string membershipUserLogin);

        [OperationContract]
        object[] GetFixedAssetsByContractor(int contractor);
    }
}
