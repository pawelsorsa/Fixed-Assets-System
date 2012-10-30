using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssetsTransactions;
using FixedAssets.Abstracts.Transactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IPersonTransactions
    {
        public void AddPerson(EF_ZMTdbEntities.Person person)
        {
            PersonTransactions transaction = new PersonTransactions();
            transaction.AddPerson(person);
        }

        public void DeletePerson(EF_ZMTdbEntities.Person person)
        {
            PersonTransactions transaction = new PersonTransactions();
            transaction.DeletePerson(person);
        }

        public void EditPerson(EF_ZMTdbEntities.Person person)
        {
            PersonTransactions transaction = new PersonTransactions();
            transaction.EditPerson(person);
        }
    }
}
