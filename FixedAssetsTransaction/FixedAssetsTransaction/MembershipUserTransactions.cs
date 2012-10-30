using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF_ZMTdbEntities;
using EF_ZMT_DbContext;
using System.Data;
using System.Data.Entity;
using FixedAssets.Abstracts.Transactions;
using System.ServiceModel;

namespace FixedAssetsTransactions
{
    public sealed class MembershipUserTransactions : IMembershipUserTransactions
    {
        public void AddMembershipUser(MembershipUser membershipUser)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.MembershipUsers.AddObject(membershipUser);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać użytkownika. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteMembershipUser(MembershipUser membershipUser)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.MembershipUsers.Attach(membershipUser);
                    context.Context.MembershipUsers.DeleteObject(membershipUser);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć użytkownika. Prawdopodobnie nie istnieje"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditMembershipUser(MembershipUser membershipUser)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    MembershipUser originalRole = context.Context.MembershipUsers.FirstOrDefault(r => r.login == membershipUser.login);
                    context.Context.MembershipUsers.ApplyCurrentValues(membershipUser);
                    context.SaveChanges();

                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się edytować użytkownika. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
