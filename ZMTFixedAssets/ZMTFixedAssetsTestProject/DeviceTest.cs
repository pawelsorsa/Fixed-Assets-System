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
    public class DeviceTest
    {
        [TestMethod]
        public void CountDevices()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a=>a.Devices).Returns(new Device[]
            {
                new Device { id = 1, model = "11111" },
                new Device { id = 2, model = "22222" },
                new Device { id = 3, model = "33333" },
                new Device { id = 4, model = "44444" },
                new Device { id = 5, model = "55555" },
                new Device { id = 6, model = "66666" },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            int count = ctrl.CountDevices();
            Assert.IsNotNull(count);
            Assert.AreEqual(ctrl.CountDevices(), 6);
        }

        [TestMethod]
        public void GetAllDevices()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, model = "11111" },
                new Device { id = 2, model = "22222" },
                new Device { id = 3, model = "33333" },
                new Device { id = 4, model = "44444" },
                new Device { id = 5, model = "55555" },
                new Device { id = 6, model = "66666" },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            object[] temp = ctrl.GetAllDevices();
            Assert.AreEqual(temp.Length, 6);
            Assert.AreEqual(((Device)temp[3]).model, "44444");
        }

        [TestMethod]
        public void GetDeviceById()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, model = "11111" },
                new Device { id = 2, model = "22222" },
                new Device { id = 3, model = "33333" },
                new Device { id = 4, model = "44444" },
                new Device { id = 5, model = "55555" },
                new Device { id = 6, model = "66666" },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            Device temp = ctrl.GetDeviceById(4);
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.model, "44444");
            temp = ctrl.GetDeviceById(7);
            Assert.IsNull(temp);
        }

        [TestMethod]
        public void GetDevicesByPheripheralDeviceId()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, id_peripheral_device = 3 },
                new Device { id = 2, id_peripheral_device = 3 },
                new Device { id = 3, id_peripheral_device = 9 },
                new Device { id = 4, id_peripheral_device = 4 },
                new Device { id = 5, id_peripheral_device = 1 },
                new Device { id = 6, id_peripheral_device = 3 },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            object [] temp = ctrl.GetDevicesByPheripheralDeviceId(3);
            Assert.AreEqual(temp.Length, 3);
            temp = ctrl.GetDevicesByPheripheralDeviceId(11);
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetDevicesBySerialNumber()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, serial_number = "11111" },
                new Device { id = 2, serial_number = "22222" },
                new Device { id = 3, serial_number = "33333" },
                new Device { id = 4, serial_number = "11111" },
                new Device { id = 5, serial_number = "55555" },
                new Device { id = 6, serial_number = "66666" },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            object[] temp = ctrl.GetDevicesBySerialNumber("11111");
            Assert.AreEqual(temp.Length, 2);
            temp = ctrl.GetDevicesBySerialNumber("33333");
            Assert.AreEqual(temp.Length, 1);
            temp = ctrl.GetDevicesBySerialNumber("77777");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetDevicesByIpAddress()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, ip_address = "10.203.192.10" },
                new Device { id = 2, ip_address = "10.203.192.11"  },
                new Device { id = 3, ip_address = "10.203.192.12"  },
                new Device { id = 4, ip_address = "10.203.192.13"  },
                new Device { id = 5, ip_address = "10.203.192.14"  },
                new Device { id = 6, ip_address = "10.203.192.10"  },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            object [] temp = ctrl.GetDevicesByIpAddress("10.203.192.10");
            Assert.AreEqual(temp.Length, 2);
            temp = ctrl.GetDevicesByIpAddress("10.203.192.11");
            Assert.AreEqual(temp.Length, 1);
            temp = ctrl.GetDevicesByIpAddress("10.203.192.15");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetDeviceByMacAddress()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, mac_address = "11111" },
                new Device { id = 2, mac_address = "22222" },
                new Device { id = 3, mac_address = "33333" },
                new Device { id = 4, mac_address = "44444" },
                new Device { id = 5, mac_address = "55555" },
                new Device { id = 6, mac_address = "66666" },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            Device temp = ctrl.GetDeviceByMacAddress("44444");
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.id, 4);
            temp = ctrl.GetDeviceByMacAddress("77777");
            Assert.IsNull(temp);
        }

        [TestMethod]
        public void GetDevicesByProducer()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, producer = "kyocera" },
                new Device { id = 2, producer = "hp" },
                new Device { id = 3, producer = "kyocera" },
                new Device { id = 4, producer = "kyocera" },
                new Device { id = 5, producer = "toshiva" },
                new Device { id = 6, producer = "kyocera" },
                new Device { id = 6, producer = null }
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            object [] temp = ctrl.GetDevicesByProducer("kyocera");
            Assert.AreEqual(temp.Length, 4);
            Assert.AreEqual(((Device)temp[2]).id, 4);
            temp = ctrl.GetDevicesByProducer("sony");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetDevicesByModel()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, model = "11111" },
                new Device { id = 2, model = "22222" },
                new Device { id = 3, model = "33333" },
                new Device { id = 4, model = "44444" },
                new Device { id = 5, model = "55555" },
                new Device { id = 6, model = "11111" },
                new Device { id = 6, model = null },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            object [] temp = ctrl.GetDevicesByModel("11111");
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((Device)temp[1]).id, 6);
            temp = ctrl.GetDevicesByModel("666666");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetDevicesByFixedAssetId()
        {
            Mock<IDeviceRepository> mock = new Mock<IDeviceRepository>();
            mock.Setup(a => a.Devices).Returns(new Device[]
            {
                new Device { id = 1, id_fixed_asset = 491000111 },
                new Device { id = 2, id_fixed_asset = 491000112 },
                new Device { id = 3, id_fixed_asset = 491000113 },
                new Device { id = 4, id_fixed_asset = 491000111 },
                new Device { id = 5, id_fixed_asset = 491000111 },
                new Device { id = 6, id_fixed_asset = 491000111 },
            }.AsQueryable());

            DeviceController ctrl = new DeviceController(mock.Object);
            object[] temp = ctrl.GetDevicesByFixedAssetId(491000111);
            Assert.AreEqual(temp.Length, 4);
            Assert.AreEqual(((Device)temp[2]).id, 5);
            temp = ctrl.GetDevicesByFixedAssetId(491000331);
            Assert.AreEqual(temp.Length, 0);
        }

    }
}
