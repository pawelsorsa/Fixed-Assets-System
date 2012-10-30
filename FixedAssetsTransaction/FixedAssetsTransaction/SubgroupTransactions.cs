using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FixedAssets.Abstracts.Transactions;
using EF_ZMTdbEntities;
using System.ServiceModel;

namespace FixedAssetsTransactions
{
    public sealed class SubgroupTransactions : ISubgroupTransactions
    {
        public void AddSubgroup(Subgroup subgroup)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Subgroups.AddObject(subgroup);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać podgrupy. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteSubgroup(Subgroup subgroup)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Subgroups.Attach(subgroup);
                    context.Context.Subgroups.DeleteObject(subgroup);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć podgrupy. Prawdopodobnie nie istnieje"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditSubgroup(Subgroup subgroup)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Subgroups.Attach(subgroup);
                    context.Context.ObjectStateManager.ChangeObjectState(subgroup, System.Data.EntityState.Modified);
                    context.Context.Subgroups.ApplyChanges(subgroup);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się edytować podgrupy. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
