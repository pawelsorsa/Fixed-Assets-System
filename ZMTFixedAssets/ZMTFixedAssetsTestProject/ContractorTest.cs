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
    public class ContractorTest
    {
        [TestMethod]
        public void CountContractors()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, name = "Firma1" },
                new Contractor { id = 2, name = "Firma2" },
                new Contractor { id = 3, name = "Firma3" },
                new Contractor { id = 4, name = "Firma4" },
                new Contractor { id = 5, name = "Firma5" },
                new Contractor { id = 6, name = "Firma6" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            Assert.AreEqual(ctrl.CountContractors(), 6);
        }


        [TestMethod]
        public void GetAllContractors()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, name = "Firma1" },
                new Contractor { id = 2, name = "Firma2" },
                new Contractor { id = 3, name = "Firma3" },
                new Contractor { id = 4, name = "Firma4" },
                new Contractor { id = 5, name = "Firma5" },
                new Contractor { id = 6, name = "Firma6" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            Object[] temp = ctrl.GetAllContractors();
            Assert.AreEqual(temp.Length, 6);
            Assert.AreEqual(((Contractor)temp[3]).name, "Firma4");
        }

        [TestMethod]
        public void GetContractorById()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, name = "Firma1" },
                new Contractor { id = 2, name = "Firma2" },
                new Contractor { id = 3, name = "Firma3" },
                new Contractor { id = 4, name = "Firma4" },
                new Contractor { id = 5, name = "Firma5" },
                new Contractor { id = 6, name = "Firma6" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            Contractor temp = ctrl.GetContractorById(4);
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.name, "Firma4");

            temp = ctrl.GetContractorById(8);
            Assert.IsNull(temp);
        }

        [TestMethod]
        public void GetContractorByNip()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, nip = 111111 },
                new Contractor { id = 2, nip = 222222 },
                new Contractor { id = 3, nip = 333333 },
                new Contractor { id = 4, nip = 444444 },
                new Contractor { id = 5, nip = 555555 },
                new Contractor { id = 6, nip = 666666 }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            Contractor temp = ctrl.GetContractorByNip(444444);
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.id, 4);

            temp = ctrl.GetContractorByNip(888888);
            Assert.IsNull(temp);
        }

        [TestMethod]
        public void GetContractorByName()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, name = "Firma1" },
                new Contractor { id = 2, name = "Firma2" },
                new Contractor { id = 3, name = "Firma3" },
                new Contractor { id = 4, name = "Firma4" },
                new Contractor { id = 5, name = "Firma5" },
                new Contractor { id = 6, name = "Firma6" },
                new Contractor { id = 7, name = "Firma4" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            Object [] temp = ctrl.GetContractorsByName("Firma4");
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((Contractor)temp[1]).name, "Firma4");

            temp = ctrl.GetContractorsByName("Firma2");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Contractor)temp[0]).name, "Firma2");

            temp = ctrl.GetContractorsByName("Firma8");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetContractorByAccountNumber()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, account_number = "111111" },
                new Contractor { id = 2, account_number = "222222" },
                new Contractor { id = 3, account_number = "333333" },
                new Contractor { id = 4, account_number = "444444" },
                new Contractor { id = 5, account_number = "555555" },
                new Contractor { id = 6, account_number = "666666" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            Contractor temp = ctrl.GetContractorByAccountNumber("333333");
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.id, 3);

            temp = ctrl.GetContractorByAccountNumber("777777");
            Assert.IsNull(temp);
        }

        [TestMethod]
        public void GetContractorsByStreet()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, street = "Spławy 2a" },
                new Contractor { id = 2, street = "Wrocławska 8" },
                new Contractor { id = 3, street = "Spławy 2a" },
                new Contractor { id = 4, street = "Karmelicka 9"},
                new Contractor { id = 5, street = "Jana Pawła 16" },
                new Contractor { id = 6, street = "Spławy 2a" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            object [] temp = ctrl.GetContractorsByStreet("Spławy 2a");
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Contractor)temp[2]).id, 6);

            temp = ctrl.GetContractorsByStreet("Karmelicka 9");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Contractor)temp[0]).id, 4);

            temp = ctrl.GetContractorsByStreet("Warszawska 19");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetContractorsByCity()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, city = "Kraków" },
                new Contractor { id = 2, city = "Kraków" },
                new Contractor { id = 3, city = "Warszawa" },
                new Contractor { id = 4, city = "Bydgoszcz" },
                new Contractor { id = 5, city = "Łódź" },
                new Contractor { id = 6, city = "Kraków" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            object[] temp = ctrl.GetContractorsByCity("Kraków");
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Contractor)temp[2]).id, 6);

            temp = ctrl.GetContractorsByCity("Warszawa");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Contractor)temp[0]).id,3 );

            temp = ctrl.GetContractorsByCity("Wrocław");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetContractorsByCountry()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, country = "Polska" },
                new Contractor { id = 2, country = "Holandia" },
                new Contractor { id = 3, country = "Polska" },
                new Contractor { id = 4, country = "Niemcy" },
                new Contractor { id = 5, country = "Polska" },
                new Contractor { id = 6, country = "Polska" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            object[] temp = ctrl.GetContractorsByCountry("Polska");
            Assert.AreEqual(temp.Length, 4);
            Assert.AreEqual(((Contractor)temp[3]).id, 6);

            temp = ctrl.GetContractorsByCountry("Niemcy");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Contractor)temp[0]).id, 4);

            temp = ctrl.GetContractorsByCountry("Czechy");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetContractorsByPostalCode()
        {
            Mock<IContractorRepository> mock = new Mock<IContractorRepository>();
            mock.Setup(a => a.Contractors).Returns(new Contractor[]
            {
                new Contractor { id = 1, postal_code = "31-987" },
                new Contractor { id = 2, postal_code = "26-110" },
                new Contractor { id = 3, postal_code = "01-585" },
                new Contractor { id = 4, postal_code = "22-151" },
                new Contractor { id = 5, postal_code = "31-987" },
                new Contractor { id = 6, postal_code = "31-987" }
            }.AsQueryable());

            ContractorController ctrl = new ContractorController(mock.Object);
            object[] temp = ctrl.GetContractorsByPostalCode("31-987");
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Contractor)temp[2]).id, 6);

            temp = ctrl.GetContractorsByPostalCode("01-585");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Contractor)temp[0]).id, 3);

            temp = ctrl.GetContractorsByPostalCode("11-511");
            Assert.AreEqual(temp.Length, 0);
        }


    }
}
