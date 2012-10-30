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
    public sealed class MembershipRoleTransactions : IMembershipRoleTransactions
    {
        public void AddMembershipRole(MembershipRole role)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.MembershipRoles.AddObject(role);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać roli. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteMembershipRole(MembershipRole role)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.MembershipRoles.Attach(role);
                    context.Context.MembershipRoles.DeleteObject(role);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć roli. Prawdopodobnie nie istnieje"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditMembershipRole(MembershipRole role)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    MembershipRole originalRole = context.Context.MembershipRoles.FirstOrDefault(r => r.id == role.id);
                    context.Context.MembershipRoles.ApplyCurrentValues(role);
                    context.SaveChanges();

                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się edytować roli. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
