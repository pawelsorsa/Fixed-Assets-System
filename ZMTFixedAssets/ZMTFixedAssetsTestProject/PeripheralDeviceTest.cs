using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EF_ZMTdbEntities;
using Moq;
using FixedAssets.Abstracts.Repositories;
using FixedAssets.Concrete.Controllers;

namespace ZMTFixedAssetsTestProject
{
    [TestClass]
    public class PeripheralDeviceTest
    {
        [TestMethod]
        public void TestPeripheralDevices()
        {
            Mock<IPeripheralDeviceRepository> mock = new Mock<IPeripheralDeviceRepository>();
            mock.Setup(a => a.PeripheralDevices).Returns(new PeripheralDevice[]
            {
                new PeripheralDevice { id = 1, name = "jednostka centralna" },
                new PeripheralDevice { id = 2, name = "monitor" },
                new PeripheralDevice { id = 3, name = "UPS" },
                new PeripheralDevice { id = 4, name = "drukarka" },
                new PeripheralDevice { id = 5, name = "skaner" },
            }.AsQueryable());

            PeripheralDeviceController ctrl = new PeripheralDeviceController(mock.Object);
            int count = ctrl.CountPeripheralDevices();
            Assert.IsNotNull(count);
            Assert.AreEqual(count, 5);

            PeripheralDevice device = ctrl.GetPeripheralDeviceById(3);
            Assert.AreEqual(device.name, "UPS");
            Assert.IsNotNull(device);
           
            device = ctrl.GetPeripheralDeviceById(8);
            Assert.IsNull(device);

            device = ctrl.GetPeripheralDeviceByName("skaner");
            Assert.IsNotNull(device);
            Assert.AreEqual(device.id, 5);

            device = ctrl.GetPeripheralDeviceByName("router");
            Assert.IsNull(device);

            object[] temp = ctrl.GetAllPeripheralDevices();
            Assert.AreEqual(temp.Length, 5);
            Assert.AreEqual(((PeripheralDevice)temp[3]).id, 4);
        }
    }
}
