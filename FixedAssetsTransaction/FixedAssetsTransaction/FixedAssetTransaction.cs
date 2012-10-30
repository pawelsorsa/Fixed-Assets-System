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
    public sealed class FixedAssetTransactions : IFixedAssetTransactions
    {
        public void AddFixedAsset(FixedAsset fixedAsset)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.FixedAssets.AddObject(fixedAsset);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać środka trwałego. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteFixedAsset(FixedAsset fixedAsset)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.FixedAssets.Attach(fixedAsset);
                    context.Context.FixedAssets.DeleteObject(fixedAsset);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć środka trwałego. Prawdopodobnie nie istnieje"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditFixedAsset(FixedAsset fixedAsset)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    FixedAsset originalFixedAsset = context.Context.FixedAssets.FirstOrDefault(f => f.id == fixedAsset.id);
                    context.Context.FixedAssets.ApplyCurrentValues(fixedAsset);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się edytować środka trwałego. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
