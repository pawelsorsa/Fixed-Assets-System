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
    public sealed class SectionTransactions : ISectionTransactions
    {
        public void AddSection(Section section)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Sections.AddObject(section);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać sekcji. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteSection(Section section)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Sections.Attach(section);
                    context.Context.Sections.DeleteObject(section);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć sekcji. Przepisz użytkowników do innej sekcji a następnie usuń daną sekcję."));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditSection(Section section)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                       // Section originalSection = context.Context.Sections.FirstOrDefault(s => s.id == section.id);
                        context.Context.Sections.Attach(section);
                        context.Context.ObjectStateManager.ChangeObjectState(section, System.Data.EntityState.Modified);
                        context.Context.Sections.ApplyChanges(section);
                        context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się edytować sekcji. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
