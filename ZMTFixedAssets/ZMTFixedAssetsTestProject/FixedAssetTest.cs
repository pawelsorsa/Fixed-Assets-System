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
    public class FixedAssetTest
    {
        [TestMethod]
        public void CountFixedAssets()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a=>a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111" },
                new FixedAsset { id = 2, inventory_number = "002/4/22222" },
                new FixedAsset { id = 3, inventory_number = "002/4/33333" },
                new FixedAsset { id = 4, inventory_number = "002/4/44444" },
                new FixedAsset { id = 5, inventory_number = "002/4/55555" },
                new FixedAsset { id = 6, inventory_number = "002/4/66666" }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            int count = ctrl.CountFixedAssets();
            Assert.IsNotNull(count);
            Assert.AreEqual(ctrl.CountFixedAssets(), 6);           
        }


        [TestMethod]
        public void GetAllFixedAssets()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111" },
                new FixedAsset { id = 2, inventory_number = "002/4/22222" },
                new FixedAsset { id = 3, inventory_number = "002/4/33333" },
                new FixedAsset { id = 4, inventory_number = "002/4/44444" },
                new FixedAsset { id = 5, inventory_number = "002/4/55555" },
                new FixedAsset { id = 6, inventory_number = "002/4/66666" }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetAllFixedAssets();
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.Length, 6);
            Assert.AreEqual(((FixedAsset)temp[3]).inventory_number, "002/4/44444");
        }

        [TestMethod]
        public void GetFixedAssetById()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111" },
                new FixedAsset { id = 2, inventory_number = "002/4/22222" },
                new FixedAsset { id = 3, inventory_number = "002/4/33333" },
                new FixedAsset { id = 4, inventory_number = "002/4/44444" },
                new FixedAsset { id = 5, inventory_number = "002/4/55555" },
                new FixedAsset { id = 6, inventory_number = "002/4/66666" }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            FixedAsset temp = ctrl.GetFixedAssetById(4);
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.inventory_number, "002/4/44444");

            temp = ctrl.GetFixedAssetById(7);
            Assert.IsNull(temp);

        }

        [TestMethod]
        public void GetFixedAssetByInventoryNumber()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111" },
                new FixedAsset { id = 2, inventory_number = "002/4/22222" },
                new FixedAsset { id = 3, inventory_number = "002/4/33333" },
                new FixedAsset { id = 4, inventory_number = "002/4/44444" },
                new FixedAsset { id = 5, inventory_number = "002/4/55555" },
                new FixedAsset { id = 6, inventory_number = "002/4/66666" }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            FixedAsset temp = ctrl.GetFixedAssetByInventoryNumber("002/4/44444");
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.id, 4);
            temp = ctrl.GetFixedAssetByInventoryNumber("002/4/77777");
            Assert.IsNull(temp);
        }


        [TestMethod]
        public void GetFixedAssetsByPersonId()
        {
            Person person = new Person() { id = 5, name = "Jan", surname = "Kowalski" };

            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", id_person = person.id  },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", id_person = 3 },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", id_person = person.id},
                new FixedAsset { id = 4, inventory_number = "002/4/44444", id_person = 1 },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", id_person = 8 },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", id_person = person.id }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object [] temp = ctrl.GetFixedAssetsByPersonId(person.id);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((FixedAsset)temp[1]).inventory_number, "002/4/33333");
            temp = ctrl.GetFixedAssetsByPersonId(11);
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByActivationDate()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", date_of_activation = new DateTime(2001, 01, 27) },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", date_of_activation = new DateTime(2001, 02, 12) },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", date_of_activation = new DateTime(2005, 05, 01) },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", date_of_activation = new DateTime(2016, 01, 09) },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", date_of_activation = new DateTime(2008, 12, 22) },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", date_of_activation = new DateTime(2005, 05, 01) }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByActivationDate(new DateTime(2005, 05, 01));
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((FixedAsset)temp[1]).id, 6);
            temp = ctrl.GetFixedAssetsByActivationDate(new DateTime(2010, 05, 01));
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByRangeActivationDate()
        {

            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", date_of_activation = new DateTime(2001, 01, 27) },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", date_of_activation = new DateTime(2001, 02, 12) },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", date_of_activation = new DateTime(2005, 05, 01) },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", date_of_activation = new DateTime(2006, 01, 09) },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", date_of_activation = new DateTime(2008, 12, 22) },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", date_of_activation = new DateTime(2010, 05, 01) }
            }.AsQueryable());


            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByRangeActivationDate(new DateTime(2001, 01, 01), 
                new DateTime(2006, 01, 10));
            Assert.AreEqual(temp.Length, 4);
            temp = ctrl.GetFixedAssetsByRangeActivationDate(new DateTime(2008, 12, 01),
                new DateTime(2010, 01, 10));
            Assert.AreEqual(temp.Length, 1);

            temp = ctrl.GetFixedAssetsByRangeActivationDate(new DateTime(2011, 12, 01),
                new DateTime(2012, 01, 10));
            Assert.AreEqual(temp.Length, 0);
            temp = ctrl.GetFixedAssetsByRangeActivationDate(
                new DateTime(2006, 01, 10), (new DateTime(2005, 06, 01)));
            Assert.AreEqual(temp.Length, 0);
        }


        [TestMethod]
        public void GetFixedAssetBySerialNumber()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", serial_number = "111111" },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", serial_number = "222222" },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", serial_number = "333333" },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", serial_number = "444444" },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", serial_number = "555555" },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", serial_number = "666666" }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            FixedAsset temp = ctrl.GetFixedAssetBySerialNumber("444444");
            Assert.IsNotNull(temp);
            Assert.AreEqual(((FixedAsset)temp).inventory_number, "002/4/44444");
            temp = ctrl.GetFixedAssetBySerialNumber("777777");
            Assert.IsNull(temp);
        }

        [TestMethod]
        public void GetFixedAssetsByMPK()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", MPK = "W10W20A006" },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", MPK = "A10W02S310" },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", MPK = "W10W20A006" },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", MPK = "TX600A200" },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", MPK = "W10W20B006" },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", MPK = "W10W20A006" }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByMPK("W10W20A006");
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((FixedAsset)temp[2]).inventory_number, "002/4/66666");

            temp = ctrl.GetFixedAssetsByMPK("TX600A200");
            Assert.AreEqual(temp.Length, 1);

            temp = ctrl.GetFixedAssetsByMPK("W10W20D006");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByLocalization()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", localization = "Kraków, ul. Spławy 2a, pok. 10" },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", localization = "Warszawa, ul. Poskarbińska 2, pok. 18" },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", localization = "Kraków, ul. Spławy 2a, pok. 10" },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", localization = "Bydgoszcz, ul.Ludwikowo 1, pok. 100" },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", localization = "Kraków, ul. Spławy 2a, pok. 10" },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", localization = "Bydgoszcz, ul. Ludwikowo 1, pok. 108" }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByLocalization("Kraków, ul. Spławy 2a, pok. 10");
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((FixedAsset)temp[2]).inventory_number, "002/4/55555");
           
            temp = ctrl.GetFixedAssetsByLocalization("Bydgoszcz, ul. Ludwikowo 1, pok. 108");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((FixedAsset)temp[0]).inventory_number, "002/4/66666");
            
            temp = ctrl.GetFixedAssetsByLocalization("Poznań, ul. Matejki 33, pok. 16");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByKindId()
        {
            Kind rodzaj = new Kind { id = 1, name = "Zestawy komputerowe" };

            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", id_kind = rodzaj.id },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", id_kind = 5 },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", id_kind = 3 },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", id_kind = rodzaj.id},
                new FixedAsset { id = 5, inventory_number = "002/4/55555", id_kind = 2 },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", id_kind = rodzaj.id }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByKindId(rodzaj.id);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((FixedAsset)temp[2]).inventory_number, "002/4/66666");

            temp = ctrl.GetFixedAssetsByKindId(2);
            Assert.AreEqual(temp.Length, 1);

            temp = ctrl.GetFixedAssetsByKindId(8);
            Assert.AreEqual(temp.Length, 0);
        }


        [TestMethod]
        public void GetFixedAssetsBySubgroupId()
        {
            Subgroup podrodzaj = new Subgroup { id = 1, name = "Środki wysokiej wartości", short_name = "N491" };

            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", id_subgroup = podrodzaj.id },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", id_subgroup = podrodzaj.id },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", id_subgroup = 3 },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", id_subgroup = 4 },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", id_subgroup = 6 },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", id_subgroup = podrodzaj.id }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsBySubgroupId(podrodzaj.id);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((FixedAsset)temp[2]).inventory_number, "002/4/66666");

            temp = ctrl.GetFixedAssetsBySubgroupId(6);
            Assert.AreEqual(temp.Length, 1);

            temp = ctrl.GetFixedAssetsBySubgroupId(8);
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByLastModifiedDate()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", last_modified_date = new DateTime(2001, 01, 27) },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", last_modified_date  = new DateTime(2001, 01, 27) },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", last_modified_date  = new DateTime(2005, 05, 01) },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", last_modified_date  = new DateTime(2006, 01, 09) },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", last_modified_date  = new DateTime(2008, 12, 22) },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", last_modified_date  = new DateTime(2010, 05, 01) }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByLastModifiedDate(new DateTime(2001, 01, 27));
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((FixedAsset)temp[1]).inventory_number, "002/4/22222");

            temp = ctrl.GetFixedAssetsByLastModifiedDate(new DateTime(201, 01, 14));
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByRangeLastModifiedDate()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", last_modified_date = new DateTime(2001, 01, 27) },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", last_modified_date  = new DateTime(2001, 03, 14) },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", last_modified_date  = new DateTime(2007, 05, 01) },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", last_modified_date  = new DateTime(2006, 01, 09) },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", last_modified_date  = new DateTime(2008, 12, 22) },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", last_modified_date  = new DateTime(2010, 05, 01) }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByRangeLastModifiedDate(new DateTime(2001, 01, 27), new DateTime(2008, 12, 22));
            Assert.AreEqual(temp.Length, 5);

            temp = ctrl.GetFixedAssetsByRangeLastModifiedDate(new DateTime(2008, 12, 22), new DateTime(2001, 01, 27));
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByLastModifiedId()
        {
            Person person = new Person() { id = 15, name = "Jan", surname = "Kowalski" };

            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", last_modifed_login = 15 },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", last_modifed_login = 1 },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", last_modifed_login = 2 },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", last_modifed_login = 5 },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", last_modifed_login = 15 },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", last_modifed_login = 15 }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByLastModifiedId(person.id);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((FixedAsset)temp[2]).inventory_number, "002/4/66666");

            temp = ctrl.GetFixedAssetsByLastModifiedId(2);
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((FixedAsset)temp[0]).inventory_number, "002/4/33333");

            temp = ctrl.GetFixedAssetsByLastModifiedId(24);
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsToCassation()
        {
            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", cassation = false },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", cassation = true },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", cassation = false },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", cassation = false },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", cassation = false },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", cassation = true }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsToCassation();
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((FixedAsset)temp[1]).inventory_number, "002/4/66666");
        }

        [TestMethod]
        public void GetFixedAssetsByCreator()
        {
            Person creator = new Person() { id = 15, name = "Jan", surname = "Kowalski" };

            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", created_by = creator.id },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", created_by = creator.id },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", created_by = 2 },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", created_by = creator.id },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", created_by = 9 },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", created_by = creator.id }
            }.AsQueryable());

            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByCreator(creator.id);
            Assert.AreEqual(temp.Length, 4);
            Assert.AreEqual(((FixedAsset)temp[2]).inventory_number, "002/4/44444");

            temp = ctrl.GetFixedAssetsByCreator(9);
            Assert.AreEqual(temp.Length, 1);

            temp = ctrl.GetFixedAssetsByCreator(7);
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetFixedAssetsByContractor()
        {
            Contractor contractor = new Contractor() { id = 16, name = "Firma1" };

            Mock<IFixedAssetRepository> mock = new Mock<IFixedAssetRepository>();
            mock.Setup(a => a.FixedAssets).Returns(new FixedAsset[]
            {
                new FixedAsset { id = 1, inventory_number = "002/4/11111", id_contractor = contractor.id },
                new FixedAsset { id = 2, inventory_number = "002/4/22222", id_contractor = 15 },
                new FixedAsset { id = 3, inventory_number = "002/4/33333", id_contractor = contractor.id },
                new FixedAsset { id = 4, inventory_number = "002/4/44444", id_contractor = 12 },
                new FixedAsset { id = 5, inventory_number = "002/4/55555", id_contractor = contractor.id },
                new FixedAsset { id = 6, inventory_number = "002/4/66666", id_contractor = 18 }
            }.AsQueryable());
            FixedAssetController ctrl = new FixedAssetController(mock.Object);
            object[] temp = ctrl.GetFixedAssetsByContractor(contractor.id);
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((FixedAsset)temp[2]).id, 5);

            temp = ctrl.GetFixedAssetsByContractor(12);
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((FixedAsset)temp[0]).id, 4);

            temp = ctrl.GetFixedAssetsByContractor(28);
            Assert.AreEqual(temp.Length, 0);
        }
    }
}
