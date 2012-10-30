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
    public sealed class KindTransactions : IKindTransactions
    {
        public void AddKind(Kind kind)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Kinds.AddObject(kind);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać rodzaju. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteKind(Kind kind)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Kinds.Attach(kind);
                    context.Context.Kinds.DeleteObject(kind);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć rodzaju. Prawdopodobnie nie istnieje"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditKind(Kind kind)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    Kind originalKind = context.Context.Kinds.FirstOrDefault(k => k.id == kind.id);
                    context.Context.Kinds.ApplyCurrentValues(kind);
                    context.SaveChanges();

                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się edytować rodzaju. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
