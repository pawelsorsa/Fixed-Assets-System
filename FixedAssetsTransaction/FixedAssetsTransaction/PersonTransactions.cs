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
    public sealed class PersonTransactions : IPersonTransactions
    {
        public void AddPerson(EF_ZMTdbEntities.Person person)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {   
                    context.Context.People.AddObject(person);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException("Użytkownik o podanym ID istnieje. Popraw dane i spróbuj ponownie.");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeletePerson(EF_ZMTdbEntities.Person person)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.People.Attach(person);
                    context.Context.People.DeleteObject(person);
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

        public void EditPerson(EF_ZMTdbEntities.Person person)
        {

            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    Person originalPerson = context.Context.People.FirstOrDefault(p => p.id == person.id);
                    context.Context.People.ApplyCurrentValues(person);
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
