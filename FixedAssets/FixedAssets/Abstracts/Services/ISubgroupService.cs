using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface ISubgroupService
    {
        [OperationContract]
        int CountSubgroups();

        [OperationContract]
        object[] GetAllSubgroups();

        [OperationContract]
        Subgroup GetSubgroupById(int id);

        [OperationContract]
        Subgroup GetSubgroupByName(string name);

        [OperationContract]
        Subgroup GetSubgroupByShortName(string shortName);
    }
}
