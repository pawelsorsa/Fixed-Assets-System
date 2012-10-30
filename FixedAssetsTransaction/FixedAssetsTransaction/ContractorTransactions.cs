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
    public sealed class ContractorTransactions : IContractorTransactions
    {
        public void AddContractor(EF_ZMTdbEntities.Contractor contractor)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Contractors.AddObject(contractor);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać kontrahenta. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteContractor(EF_ZMTdbEntities.Contractor contractor)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Contractors.Attach(contractor);
                    context.Context.Contractors.DeleteObject(contractor);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć kontrahenta. Prawdopodobnie kontrahent nie istnieje"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditContractor(EF_ZMTdbEntities.Contractor contractor)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    Contractor originalContractor = context.Context.Contractors.FirstOrDefault(c => c.id == contractor.id);
                    context.Context.Contractors.ApplyCurrentValues(contractor);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało sie edytować kontrahenta. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
