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
    public class SubgroupTransactionsUnitTests
    {
        [TestMethod]
        public void CanAddSubgroup()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Subgroup");
                Subgroup subgroup = new Subgroup() { name = "Środki wysokiej wartości", short_name = "N491" };
                transaction.AddSubgroup(subgroup);
                Assert.AreEqual(context.Context.Subgroups.Count(), 1);
                subgroup = context.Context.Subgroups.FirstOrDefault(x => x.short_name == "N491");
                Assert.IsNotNull(subgroup);
                Assert.AreEqual(subgroup.name, "Środki wysokiej wartości");
            }
        }

        [TestMethod]
        public void CanEditSubgroup()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Subgroup");
                Subgroup subgroup = new Subgroup() { name = "Środki wysokiej wartości", short_name = "N491" };
                transaction.AddSubgroup(subgroup);
                Assert.AreEqual(context.Context.Subgroups.Count(), 1);
                subgroup = context.Context.Subgroups.FirstOrDefault(x => x.short_name == "N491");
                subgroup.name = "Środki niskiej wartości";
                transaction.EditSubgroup(subgroup);

                subgroup = context.Context.Subgroups.FirstOrDefault(x => x.name == "Środki niskiej wartości");
                Assert.IsNotNull(subgroup);
                Assert.AreEqual(subgroup.short_name, "N491");
                Assert.AreEqual(context.Context.Subgroups.Count(), 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantEditSubgroup()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Subgroup");
                Subgroup subgroup = new Subgroup() { name = "Środki wysokiej wartości", short_name = "N491" };
                Assert.AreEqual(context.Context.Subgroups.Count(), 0);
                transaction.EditSubgroup(subgroup);
            }
        }

        [TestMethod]
        public void CanDeleteSubgroup()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM Subgroup");
                Subgroup subgroup = new Subgroup() { name = "Środki wysokiej wartości", short_name = "N491" };
                transaction.AddSubgroup(subgroup);
                Assert.AreEqual(context.Context.Subgroups.Count(), 1);
                subgroup = context.Context.Subgroups.FirstOrDefault(x => x.short_name == "N491");
                Assert.IsNotNull(subgroup);
                Assert.AreEqual(subgroup.name, "Środki wysokiej wartości");

                transaction.DeleteSubgroup(subgroup);
                Assert.AreEqual(context.Context.Subgroups.Count(), 0);
                subgroup = context.Context.Subgroups.FirstOrDefault(x => x.short_name == "N491");
                Assert.IsNull(subgroup);
            }
        }
    }
}
