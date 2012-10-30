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
    public class FixedAssetTransactionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantAddFixedAsset()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    cassation = false,
                    date_of_activation = DateTime.Now
                };
                transaction.AddFixedAsset(asset);
            }
        }

        [TestMethod]
        public void CanAddFixedAsset()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now
                };
                transaction.AddFixedAsset(asset);

                asset = context.Context.FixedAssets.FirstOrDefault(x => x.inventory_number == "222222");
                Assert.IsNotNull(asset);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 1);
            }
        }

        [TestMethod]
        public void CanEditFixedAsset()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now,
                    MPK = "AAAAAA"
                };
                transaction.AddFixedAsset(asset);

                asset = context.Context.FixedAssets.FirstOrDefault(x => x.inventory_number == "222222");
                asset.MPK = "BBBBB";
                asset.inventory_number = "333333";
                transaction.EditFixedAsset(asset);

                asset = context.Context.FixedAssets.FirstOrDefault(x => x.inventory_number == "333333");
                Assert.IsNotNull(asset);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CantEditNotExistingFixedAsset()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now,
                    MPK = "AAAAAA"
                };
                transaction.EditFixedAsset(asset);
            }
        }


        [TestMethod]
        public void CanDeleteFixedAsset()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now,
                    MPK = "AAAAAA"
                };
                transaction.AddFixedAsset(asset);
                asset = context.Context.FixedAssets.FirstOrDefault(x => x.inventory_number == "222222");
                Assert.IsNotNull(asset);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 1);

                transaction.DeleteFixedAsset(asset);
                asset = context.Context.FixedAssets.FirstOrDefault(x => x.inventory_number == "222222");
                Assert.IsNull(asset);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 0);
            }
        }



    }
}


