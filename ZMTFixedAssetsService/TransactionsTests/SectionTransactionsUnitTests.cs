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
    public class SectionTransactionsUnitTests
    {
        [TestMethod]
        public void CantAddSection()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section section = new Section() { name = "IMZ1", email = "imz1@xxx.xxx" };
                transaction.AddSection(section);
                Assert.AreEqual(context.Context.Sections.Count(), 1);
                section = context.Context.Sections.FirstOrDefault(x => x.name == "IMZ1");
                Assert.IsNotNull(section);
            }
        }

        [TestMethod]
        public void CanEditSection()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section section = new Section() { name = "IMZ1", email = "imz1@xxx.xxx" };
                transaction.AddSection(section);
                section = context.Context.Sections.FirstOrDefault(x => x.email == "imz1@xxx.xxx");
                section.email = "imz1@ooo.ooo";
                section.locality = "Kraków";
                transaction.EditSection(section);
                section = context.Context.Sections.FirstOrDefault(x => x.name == "IMZ1");
                Assert.IsNotNull(section);
                Assert.AreEqual(section.locality, "Kraków");
                Assert.AreEqual(context.Context.Sections.Count(), 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantEditSection()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section section = new Section() { name = "IMZ1", email = "imz1@xxx.xxx" };
                transaction.EditSection(section);
                section = context.Context.Sections.FirstOrDefault(x => x.name == "IMZ1");
                Assert.IsNull(section);
                Assert.AreEqual(context.Context.Sections.Count(), 0);
            }
        }

        [TestMethod]
        public void CanDeleteSection()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section section = new Section() { name = "IMZ1", email = "imz1@xxx.xxx" };
                transaction.AddSection(section);
                Assert.AreEqual(context.Context.Sections.Count(), 1);
                section = context.Context.Sections.FirstOrDefault(x => x.name == "IMZ1");
                Assert.IsNotNull(section);
                transaction.DeleteSection(section);
                section = context.Context.Sections.FirstOrDefault(x => x.name == "IMZ1");
                Assert.IsNull(section);
                Assert.AreEqual(context.Context.Sections.Count(), 0);
            }
        }

        [TestMethod]
        public void CantDeleteSection()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Person");
                context.Context.ExecuteStoreCommand("DELETE FROM Section");
                Section section = new Section() { name = "IMZ1", email = "imz1@xxx.xxx" };
                transaction.DeleteSection(section);
                section = context.Context.Sections.FirstOrDefault(x => x.name == "IMZ1");
                Assert.IsNull(section);
                Assert.AreEqual(context.Context.Sections.Count(), 0);
            }
        }

    }
}
