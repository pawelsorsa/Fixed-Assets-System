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
    public class LicenceTest
    {
        [TestMethod]
        public void CountAndGetAllLicences()
        {
            Mock<ILicenceRepository> mock = new Mock<ILicenceRepository>();
            mock.Setup(a => a.Licences).Returns(new Licence[]
            {
                new Licence { id_number = 1, inventory_number = "aaaa" },
                new Licence { id_number = 2, inventory_number = "bbbb" },
                new Licence { id_number = 3, inventory_number = "cccc" },
                new Licence { id_number = 4, inventory_number = "dddd" },
                new Licence { id_number = 5, inventory_number = "eeee" },
            }.AsQueryable());

            LicenceController ctrl = new LicenceController(mock.Object);
            int count = ctrl.CountLicences();
            Assert.IsNotNull(count);
            Assert.AreEqual(count, 5);

            object[] temp = ctrl.GetAllLicences();
            Assert.AreEqual(temp.Length, 5);
            Assert.AreEqual(((Licence)temp[2]).inventory_number, "cccc");
        }

        [TestMethod]
        public void GetLicenceByIdOrInvNumber()
        {
            Mock<ILicenceRepository> mock = new Mock<ILicenceRepository>();
            mock.Setup(a => a.Licences).Returns(new Licence[]
            {
                new Licence { id_number = 1, inventory_number = "aaaa" },
                new Licence { id_number = 2, inventory_number = "bbbb" },
                new Licence { id_number = 3, inventory_number = "cccc" },
                new Licence { id_number = 4, inventory_number = "dddd" },
                new Licence { id_number = 5, inventory_number = "eeee" }
            }.AsQueryable());

            LicenceController ctrl = new LicenceController(mock.Object);
            Licence temp = ctrl.GetLicenceById(3);
            Assert.AreEqual(temp.inventory_number, "cccc");

            temp = ctrl.GetLicenceById(22);
            Assert.IsNull(temp);

            temp = ctrl.GetLicenceByInventoryNumber("dddd");
            Assert.AreEqual(temp.id_number, 4);

            temp = ctrl.GetLicenceByInventoryNumber("ggggg");
            Assert.IsNull(temp);
        }

        [TestMethod]
        public void GetLicencesBySerialNumber_FixedAssetId_LicenceNumber_Name()
        {
            Mock<ILicenceRepository> mock = new Mock<ILicenceRepository>();
            mock.Setup(a => a.Licences).Returns(new Licence[]
            {
                new Licence { id_number = 1, inventory_number = "aaaa", assign_fixed_asset = 1, licence_number = "1111", name = "Windows 7" },
                new Licence { id_number = 2, inventory_number = "bbbb", assign_fixed_asset = 1, licence_number = "1111", name = "Windows 7"  },
                new Licence { id_number = 3, inventory_number = "cccc", assign_fixed_asset = 2, licence_number = "2222", name = "Windows XP"  },
                new Licence { id_number = 4, inventory_number = "dddd", assign_fixed_asset = 3, licence_number = "3333", name = "SAP"  },
                new Licence { id_number = 5, inventory_number = "eeee", assign_fixed_asset = 1, licence_number = "4444", name = "AutoCAD"  }
            }.AsQueryable());

            LicenceController ctrl = new LicenceController(mock.Object);
            object[] temp = ctrl.GetLicencesByFixedAssetId(1);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Licence)temp[2]).inventory_number, "eeee");

            temp = ctrl.GetLicencesByFixedAssetId(10);
            Assert.AreEqual(temp.Length, 0);

            temp = ctrl.GetLicencesByLicenceNumber("1111");
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((Licence)temp[1]).inventory_number, "bbbb");

            temp = ctrl.GetLicencesByLicenceNumber("6666");
            Assert.AreEqual(temp.Length, 0);

            temp = ctrl.GetLicencesByName("Windows 7");
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((Licence)temp[1]).inventory_number, "bbbb");

            temp = ctrl.GetLicencesByName("SAP");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Licence)temp[0]).inventory_number, "dddd");

            temp = ctrl.GetLicencesByName("Photoshop");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetLicencesByCreatorOrLastModifiedPersonID()
        {
            Person person = new Person { id = 4, name = "Jan", surname = "Kowalski" };
            Mock<ILicenceRepository> mock = new Mock<ILicenceRepository>();
            mock.Setup(a => a.Licences).Returns(new Licence[]
            {
                new Licence { id_number = 1, inventory_number = "aaaa", created_by = person.id, last_modified_id = 9 },
                new Licence { id_number = 2, inventory_number = "bbbb", created_by = 2, last_modified_id = 2},
                new Licence { id_number = 3, inventory_number = "cccc", created_by = 3, last_modified_id = 9},
                new Licence { id_number = 4, inventory_number = "dddd", created_by = person.id, last_modified_id = 9},
                new Licence { id_number = 5, inventory_number = "eeee", created_by = 1, last_modified_id = 12}
            }.AsQueryable());

            LicenceController ctrl = new LicenceController(mock.Object);
            object[] temp = ctrl.GetLicenceByCreator(person.id);
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((Licence)temp[1]).inventory_number, "dddd");

            temp = ctrl.GetLicenceByCreator(22);
            Assert.AreEqual(temp.Length, 0);

            temp = ctrl.GetLicencesByLastModifiedPersonId(9);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Licence)temp[1]).inventory_number, "cccc");

            temp = ctrl.GetLicencesByLastModifiedPersonId(33);
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetLicencesByLastModifiedDateAndRangeDates()
        {
            Mock<ILicenceRepository> mock = new Mock<ILicenceRepository>();
            mock.Setup(a => a.Licences).Returns(new Licence[]
            {
                new Licence { id_number = 1, inventory_number = "aaaa", last_modified_date = new DateTime(2001, 01, 27) },
                new Licence { id_number = 2, inventory_number = "bbbb", last_modified_date = new DateTime(2003, 05, 11)},
                new Licence { id_number = 3, inventory_number = "cccc", last_modified_date = new DateTime(2002, 02, 02) },
                new Licence { id_number = 4, inventory_number = "dddd", last_modified_date = new DateTime(1992, 11, 13) },
                new Licence { id_number = 5, inventory_number = "eeee", last_modified_date = new DateTime(2002, 08, 17) },
                new Licence { id_number = 6, inventory_number = "ffff", last_modified_date = new DateTime(2001, 01, 27) }
            }.AsQueryable());

            LicenceController ctrl = new LicenceController(mock.Object);
            object [] temp = ctrl.GetLicencesByLastModifiedDate(new DateTime(2001, 01, 27));
            Assert.AreEqual(temp.Length, 2);
            temp = ctrl.GetLicencesByLastModifiedDate(new DateTime(2021, 01, 18));
            Assert.AreEqual(temp.Length, 0);

            temp = ctrl.GetLicencesByRangeLastModifiedDate(new DateTime(2001, 01, 27), new DateTime(2002, 08, 17));
            Assert.AreEqual(temp.Length, 4);

            temp = ctrl.GetLicencesByRangeLastModifiedDate(new DateTime(2003, 01, 27), new DateTime(1992, 08, 17));
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetLicencesByLastModifiedPersonId()
        {
            Person person = new Person { id = 5, name = "Jan", surname = "Kowalski" };

            Mock<ILicenceRepository> mock = new Mock<ILicenceRepository>();
            mock.Setup(a => a.Licences).Returns(new Licence[]
            {
                new Licence { id_number = 1, inventory_number = "aaaa", last_modified_id = person.id },
                new Licence { id_number = 2, inventory_number = "bbbb", last_modified_id = 4 },
                new Licence { id_number = 3, inventory_number = "cccc", last_modified_id = person.id },
                new Licence { id_number = 4, inventory_number = "dddd", last_modified_id = 2 },
                new Licence { id_number = 5, inventory_number = "eeee", last_modified_id = person.id }
            }.AsQueryable());

            LicenceController ctrl = new LicenceController(mock.Object);
            Object[] temp = ctrl.GetLicencesByLastModifiedPersonId(person.id);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Licence)temp[2]).inventory_number, "eeee");

            temp = ctrl.GetLicencesByLastModifiedPersonId(2);
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Licence)temp[0]).inventory_number, "dddd");

            temp = ctrl.GetLicencesByLastModifiedPersonId(52);
            Assert.AreEqual(temp.Length, 0);
        }

    }
}
