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
    public class PeripheralDeviceTransactionsUnitTests
    {
        [TestMethod]
        public void CantAddPeripheralDevice()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                FixedAssetService transaction = new FixedAssetService();
                context.Context.ExecuteStoreCommand("DELETE FROM PeripheralDevice");
                PeripheralDevice device = new PeripheralDevice() { name = "printer" };
                transaction.AddPeripheralDevice(device);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 1);
                device = context.Context.PeripheralDevices.FirstOrDefault(x => x.name == "printer");
                Assert.IsNotNull(device);
            }
        }


    }
}
