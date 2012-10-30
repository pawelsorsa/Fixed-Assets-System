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
    public class KindUnitTests
    {
        [TestMethod]
        public void CanAddKind()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Kind");
                FixedAssetService transaction = new FixedAssetService();
                Kind kind = new Kind() { name = "N491" };
                transaction.AddKind(kind);
                Assert.AreEqual(context.Context.Kinds.Count(), 1);
                kind = context.Context.Kinds.FirstOrDefault(x => x.name == "N491");
                Assert.IsNotNull(kind);
            }
        }

        [TestMethod]
        public void CanDeleteKind()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Kind");
                FixedAssetService transaction = new FixedAssetService();
                Kind kind = new Kind() { name = "N491" };
                transaction.AddKind(kind);
                Assert.AreEqual(context.Context.Kinds.Count(), 1);
                kind = context.Context.Kinds.FirstOrDefault(x => x.name == "N491");
                transaction.DeleteKind(kind);
                kind = context.Context.Kinds.FirstOrDefault(x => x.name == "N491");
                Assert.AreEqual(context.Context.Kinds.Count(), 0);
                Assert.IsNull(kind);
            }
        }

        [TestMethod]
        public void CanEditKind()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Kind");
                FixedAssetService transaction = new FixedAssetService();
                Kind kind = new Kind() { name = "N491" };
                transaction.AddKind(kind);
                Assert.AreEqual(context.Context.Kinds.Count(), 1);
                kind = context.Context.Kinds.FirstOrDefault(x => x.name == "N491");
                kind.name = "S54";
                transaction.EditKind(kind);
                kind = context.Context.Kinds.FirstOrDefault(x => x.name == "S54");
                Assert.AreEqual(context.Context.Kinds.Count(), 1);
                Assert.IsNotNull(kind);
            }
        }

    }
}


