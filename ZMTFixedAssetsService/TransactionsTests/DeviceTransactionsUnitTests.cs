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
    public class DeviceTransactionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantAddDeviceWithoutData()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Device");
                FixedAssetService transaction = new FixedAssetService();
                Device device = new Device() { model = "x400", producer = "Sony" };
                transaction.AddDevice(device);
            }
        }

        [TestMethod]
        public void CanAddDevice()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Device");
                context.Context.ExecuteStoreCommand("DELETE FROM PeripheralDevice");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                Assert.AreEqual(context.Context.Devices.Count(), 0);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 0);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 0);
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now
                };
                PeripheralDevice pd = new PeripheralDevice() { name = "Kamera" };  
                Device device = new Device() { model = "x400", producer = "Sony", PeripheralDevice = pd, FixedAsset = asset };
                transaction.AddDevice(device);
                Assert.AreEqual(context.Context.Devices.Count(), 1);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 1);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 1);
            }
        }


        [TestMethod]
        public void CanEditDevice()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Device");
                context.Context.ExecuteStoreCommand("DELETE FROM PeripheralDevice");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                Assert.AreEqual(context.Context.Devices.Count(), 0);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 0);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 0);
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now
                };
                PeripheralDevice pd = new PeripheralDevice() { name = "Kamera" };
                Device device = new Device() { model = "x400", producer = "Sony", PeripheralDevice = pd, FixedAsset = asset };
                transaction.AddDevice(device);
                Assert.AreEqual(context.Context.Devices.Count(), 1);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 1);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 1);

                pd = new PeripheralDevice() { name = "Aparat" };
                context.Context.PeripheralDevices.AddObject(pd);
                context.SaveChanges();
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 2);
                device = context.Context.Devices.FirstOrDefault(x => x.model == "x400");
                Assert.IsNotNull(device);
                device.PeripheralDevice = pd;
                device.model = "x500";
                transaction.EditDevice(device);

                device = context.Context.Devices.FirstOrDefault(x => x.model == "x500");
                Assert.IsNotNull(device);
                Assert.AreEqual(device.model, "x500");
                Assert.AreEqual(device.PeripheralDevice.name, "Aparat");
                Assert.AreEqual(context.Context.Devices.Count(), 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CantEditDevice()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Device");
                context.Context.ExecuteStoreCommand("DELETE FROM PeripheralDevice");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                Assert.AreEqual(context.Context.Devices.Count(), 0);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 0);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 0);
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now
                };
                PeripheralDevice pd = new PeripheralDevice() { name = "Kamera" };
                Device device = new Device() { model = "x400", producer = "Sony", PeripheralDevice = pd, FixedAsset = asset };
                transaction.EditDevice(device);
            }
        }

        [TestMethod]
        public void CanDeleteDevice()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Device");
                context.Context.ExecuteStoreCommand("DELETE FROM PeripheralDevice");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                Assert.AreEqual(context.Context.Devices.Count(), 0);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 0);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 0);
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now
                };
                PeripheralDevice pd = new PeripheralDevice() { name = "Kamera" };
                Device device = new Device() { model = "x400", producer = "Sony", PeripheralDevice = pd, FixedAsset = asset };
                transaction.AddDevice(device);
                Assert.AreEqual(context.Context.Devices.Count(), 1);

                transaction.DeleteDevice(device);
                Assert.AreEqual(context.Context.Devices.Count(), 0);
                device = context.Context.Devices.FirstOrDefault(x => x.model == "x400");
                Assert.IsNull(device);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantDeleteNotExistingDevice()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Device");
                context.Context.ExecuteStoreCommand("DELETE FROM PeripheralDevice");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                Assert.AreEqual(context.Context.Devices.Count(), 0);
                Assert.AreEqual(context.Context.PeripheralDevices.Count(), 0);
                Assert.AreEqual(context.Context.FixedAssets.Count(), 0);
                FixedAssetService transaction = new FixedAssetService();

                FixedAsset asset = new FixedAsset()
                {
                    inventory_number = "222222",
                    cassation = false,
                    date_of_activation = DateTime.Now
                };
                PeripheralDevice pd = new PeripheralDevice() { name = "Kamera" };
                Device device = new Device() { model = "x400", producer = "Sony", PeripheralDevice = pd, FixedAsset = asset };
                transaction.DeleteDevice(device);
            }
        }

    }
}


