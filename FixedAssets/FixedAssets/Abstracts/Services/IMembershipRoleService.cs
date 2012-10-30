using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IMembershipRoleService
    {
        [OperationContract]
        object[] GetAllRoles();

        [OperationContract]
        MembershipRole GetRoleById(int id);

        [OperationContract]
        MembershipRole GetRoleByName(string name);
    }
}
