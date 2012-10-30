using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZMTFixedAssetsService.Transactions;
using FixedAssets.Concrete.Controllers;
using EF_ZMTdbEntities;
using System.Data;
using FixedAssets.Abstracts.DbContexts;
using ZMTFixedAssetsService.Services;

namespace TransactionsTests
{
    [TestClass]
    public class ContractorTransactionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Nie udało sie dodać kontrahenta. Popraw dane i spróbuj ponownie")]
        public void CantAddContractorWithoutData()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Contractor");
                FixedAssetService transaction = new FixedAssetService();
                Contractor contractor = new Contractor() { name = "ABC", city = "Kraków"};
                transaction.AddContractor(contractor);
            }
        }

        [TestMethod]
        public void CanAddContractor()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Contractor");
                int count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 0);
                
                Contractor contractor = new Contractor()
                {
                    name = "ABC",
                    city = "Kraków",
                    nip = 555123213,
                    postal_code = "31-987",
                    street = "Królewska",
                    country = "Polska"
                };
                transaction.AddContractor(contractor);
                count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 1);
                Contractor temp = context.Context.Contractors.FirstOrDefault(x => x.name == "ABC");
                Assert.IsNotNull(temp);
                Assert.AreEqual(temp.nip, 555123213);
            }
        }

        [TestMethod]
        public void CanEditContractor()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Contractor");
                int count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 0);

                Contractor contractor = new Contractor()
                {
                    name = "ABC",
                    city = "Kraków",
                    nip = 555123213,
                    postal_code = "31-987",
                    street = "Królewska",
                    country = "Polska"
                };
                transaction.AddContractor(contractor);
                count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 1);


                Contractor temp = context.Context.Contractors.FirstOrDefault(x => x.name == "ABC");
                temp.city = "Warszawa";
                temp.street = "Radomska 8";

                transaction.EditContractor(temp);
                count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 1);

                Assert.IsNotNull(temp);
                Assert.AreEqual(temp.nip, 555123213);
                Assert.AreEqual(temp.city, "Warszawa");
                Assert.AreEqual(temp.street, "Radomska 8");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CantEditNotExistingContractor()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Contractor");
                int count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 0);

                Contractor contractor = new Contractor()
                {
                    name = "ABC",
                    city = "Kraków",
                    nip = 555123213,
                    postal_code = "31-987",
                    street = "Królewska",
                    country = "Polska"
                };
                transaction.AddContractor(contractor);

                Contractor contractor2 = new Contractor()
                {
                    name = "XXX",
                    city = "Warszawa",
                    nip = 6666666,
                    postal_code = "22-987",
                    street = "Wrocławska",
                    country = "Polska"
                };
                transaction.EditContractor(contractor2);
                count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 1);
            }
        }

        [TestMethod]
        public void CanDeleteContractor()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Contractor");
                int count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 0);

                Contractor contractor = new Contractor()
                {
                    name = "ABC",
                    city = "Kraków",
                    nip = 555123213,
                    postal_code = "31-987",
                    street = "Królewska",
                    country = "Polska"
                };
                transaction.AddContractor(contractor);
                count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 1);

                Contractor temp = context.Context.Contractors.FirstOrDefault(x => x.name == "ABC");
                transaction.DeleteContractor(temp);
                count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 0);

                temp = context.Context.Contractors.FirstOrDefault(x => x.name == "ABC");
                Assert.IsNull(temp);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Nie udało sie usunąć kontrahenta. Prawdopodobnie kontrahent nie istnieje")]
        public void CantDeleteNotExistingContractor()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Contractor");
                int count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 0);

                Contractor contractor = new Contractor()
                {
                    name = "ABC",
                    city = "Kraków",
                    nip = 555123213,
                    postal_code = "31-987",
                    street = "Królewska",
                    country = "Polska"
                };
                transaction.DeleteContractor(contractor);
                count = context.Context.Contractors.Count();
                Assert.AreEqual(count, 0);
   
            }
        }

    }
}


