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
    public class PersonTransactionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Nie udało sie dodać użytkownika. Popraw dane i spróbuj ponownie")]
        public void CantAddPersonWithoutSection()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                Person person = new Person() { id = 1, name = "Damian", surname = "Kowalski" };
                transaction.AddPerson(person);
            }
        }

        [TestMethod]
        public void CanAddPersonTransaction()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section sekcja = new Section() { name = "IMZ1" };
                Person person = new Person() { id = 1, name = "Jan", surname = "Kowalski", Section = sekcja };
                transaction.AddPerson(person);
                
                Section sekcja_temp = context.Context.Sections.FirstOrDefault(x => x.id == sekcja.id);
                Assert.AreEqual(sekcja.name, sekcja_temp.name);
                Assert.AreEqual(context.Context.Sections.Count(), 1);

                Person person_temp = context.Context.People.FirstOrDefault(x => x.id == person.id);
                Assert.AreEqual(person.id, person_temp.id);
                Assert.AreEqual(person.name, person_temp.name);
                Assert.AreEqual(context.Context.People.Count(), 1);
            }
        }

        [TestMethod]
        public void CanEditPersonTransaction()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section sekcja = new Section() { name = "IMZ1" };
                Person person = new Person() { id = 1, name = "Jan", surname = "Kowalski", email = "aaa@aaa.com", Section = sekcja };
                transaction.AddPerson(person);
                Section sekcja1 = new Section() { name = "Sekcja IMR", short_name = "IMR5" };
                transaction.AddSection(sekcja1);

                Section sekcja_temp = context.Context.Sections.FirstOrDefault(x => x.id == sekcja.id);
                Assert.AreEqual(sekcja.name, sekcja_temp.name);
                Assert.AreEqual(context.Context.Sections.Count(), 2);

                Person person_temp = context.Context.People.FirstOrDefault(x => x.id == person.id);
                Assert.IsNotNull(person_temp);
                Assert.AreEqual(person_temp.id, person_temp.id);
                Assert.AreEqual(person_temp.name, "Jan");
                Assert.AreEqual(person_temp.surname, "Kowalski");
                Assert.AreEqual(person_temp.email, "aaa@aaa.com");
                Assert.AreEqual(context.Context.People.Count(), 1);

                sekcja_temp = context.Context.Sections.FirstOrDefault(x => x.short_name == "IMR5");

                person_temp.email = "bbb@bbb.com";
                person_temp.surname = "Kowalczyk";
                person_temp.Section = sekcja_temp;
                transaction.EditPerson(person_temp);

                Person person_temp2 = context.Context.People.FirstOrDefault(x => x.id == person.id);
                Assert.AreEqual(person_temp2.surname, "Kowalczyk");
                Assert.AreEqual(person_temp2.email, "bbb@bbb.com");
                Assert.AreEqual(person_temp.Section.name, "Sekcja IMR");
                Assert.AreEqual(context.Context.People.Count(), 1);

                Assert.AreEqual(context.Context.Sections.Count(), 2);
            }
        }

        [TestMethod]
        public void CanDeletePersonTransaction()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section sekcja = new Section() { name = "IMZ1" };
                Person person = new Person() { id = 1, name = "Jan", surname = "Kowalski", Section = sekcja };
                transaction.AddPerson(person);

                Section sekcja_temp = context.Context.Sections.FirstOrDefault(x => x.id == sekcja.id);
                Assert.AreEqual(sekcja.name, sekcja_temp.name);
                Assert.AreEqual(context.Context.Sections.Count(), 1);

                Person person_temp = context.Context.People.FirstOrDefault(x => x.id == person.id);
                Assert.AreEqual(person.id, person_temp.id);
                Assert.AreEqual(person.name, person_temp.name);
                Assert.AreEqual(context.Context.People.Count(), 1);

                transaction.DeletePerson(person_temp);
                person_temp = context.Context.People.FirstOrDefault(x => x.id == person.id);
                Assert.AreEqual(context.Context.People.Count(), 0);
                Assert.IsNull(person_temp);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CantDeleteNotExistingPersonTransaction()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section sekcja = new Section() { name = "IMZ1" };
                Person person = new Person() { id = 1, name = "Jan", surname = "Kowalski", Section = sekcja };
                transaction.AddPerson(person);

                Section sekcja_temp = context.Context.Sections.FirstOrDefault(x => x.id == sekcja.id);
                Assert.AreEqual(sekcja.name, sekcja_temp.name);
                Assert.AreEqual(context.Context.Sections.Count(), 1);

                Person person_temp = new Person() { id = 22, name = "Damian", surname = "Nowak", Section = sekcja };
                transaction.DeletePerson(person_temp);
            }
        }

        [TestMethod]
        public void CantAddSection()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section sekcja1 = new Section() { name = "Sekcja IMR", short_name = "IMR5" };
                transaction.AddSection(sekcja1);
            }
        }

    }
}
