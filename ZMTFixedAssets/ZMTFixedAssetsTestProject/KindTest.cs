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
    public class KindTest
    {

        [TestMethod]
        public void GetAllKindsAndCount()
        {
            Mock<IKindRepository> mock = new Mock<IKindRepository>();
            mock.Setup(a => a.Kinds).Returns(new Kind[]
            {
                new Kind { id = 1, name = "Zestawy komputerowe" },
                new Kind { id = 2, name = "Urządzenia wyjścia" },
                new Kind { id = 3, name = "Urządzenia wejścia-wyjścia"} ,
                new Kind { id = 4, name = "Urządzenia transmisji danych"} ,
                new Kind { id = 5, name = "Oprogramowanie komputerów"} ,
            }.AsQueryable());

            KindController ctrl = new KindController(mock.Object);
            int count = ctrl.CountKinds();
            Assert.IsNotNull(count);
            Assert.AreEqual(count, 5);

            object[] temp = ctrl.GetAllKinds();
            Assert.AreEqual(temp.Length, 5);
        }


        [TestMethod]
        public void GetContractorByIdOrName()
        {
            Mock<IKindRepository> mock = new Mock<IKindRepository>();
            mock.Setup(a => a.Kinds).Returns(new Kind []
            {
                new Kind { id = 1, name = "Zestawy komputerowe" },
                new Kind { id = 2, name = "Urządzenia wyjścia" },
                new Kind { id = 3, name = "Urządzenia wejścia-wyjścia"} ,
                new Kind { id = 4, name = "Urządzenia transmisji danych"} ,
                new Kind { id = 5, name = "Oprogramowanie komputerów"} ,
            }.AsQueryable());

            KindController ctrl = new KindController(mock.Object);
            Kind temp = ctrl.GetKindById(3);
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.name, "Urządzenia wejścia-wyjścia");

            temp = ctrl.GetKindById(7);
            Assert.IsNull(temp);

            temp = ctrl.GetKindByName("Urządzenia transmisji danych");
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.id, 4);

            temp = ctrl.GetKindByName("xxxxxxxxxxxxxxxxxx");
            Assert.IsNull(temp);
        }



    }
}
