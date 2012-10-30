using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IKindService
    {
        [OperationContract]
        int CountKinds();

        [OperationContract]
        Kind GetKindById(int id);

        [OperationContract]
        Kind GetKindByName(string name);

        [OperationContract]
        object[] GetAllKinds();
    }
}
