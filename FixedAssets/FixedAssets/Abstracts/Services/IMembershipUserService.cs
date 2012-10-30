using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using EF_ZMTdbEntities;

namespace FixedAssets.Abstracts.Services
{
    [ServiceContract]
    public interface IMembershipUserService
    {
        [OperationContract]
        bool IsUserInRole(string login, string role);

        [OperationContract]
        bool IsUserActive(string login);

        [OperationContract]
        bool IsUserOnline(string login);

        [OperationContract]
        object[] GetAllUsers();

        [OperationContract]
        object[] GetOnlineUsers();

        [OperationContract]
        object[] GetActiveUsers();

        [OperationContract]
        object[] GetNonActiveUsers();

        [OperationContract]
        MembershipUser GetUserByLogin(string login);

        [OperationContract]
        MembershipUser GetUserByEmail(string email);
    }
}
