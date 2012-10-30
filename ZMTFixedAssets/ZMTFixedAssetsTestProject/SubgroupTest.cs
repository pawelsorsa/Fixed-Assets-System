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
    public class SubgroupTest
    {
        [TestMethod]
        public void TestSubgroups()
        {
            Mock<ISubgroupRepository> mock = new Mock<ISubgroupRepository>();
            mock.Setup(a => a.Subgroups).Returns(new Subgroup[]
            {
                new Subgroup { id = 1, short_name = "N491", name = "Środki niskiej wartości" },
                new Subgroup { id = 2, short_name = "S491", name = "Środki wysokiej wartości" },
                new Subgroup { id = 3, short_name = "WIN93", name = "Oprogramowanie komputerowe" },
                new Subgroup { id = 4, short_name = "WN101", name = "Inne" },
            }.AsQueryable());

            SubgroupController ctrl = new SubgroupController(mock.Object);
            int count = ctrl.CountSubgroups();
            Assert.IsNotNull(count);
            Assert.AreEqual(count, 4);

            Subgroup subgroup = ctrl.GetSubgroupById(3);
            Assert.AreEqual(subgroup.name, "Oprogramowanie komputerowe");
            Assert.IsNotNull(subgroup);

            subgroup = ctrl.GetSubgroupById(8);
            Assert.IsNull(subgroup);

            subgroup = ctrl.GetSubgroupByName("Środki wysokiej wartości");
            Assert.IsNotNull(subgroup);
            Assert.AreEqual(subgroup.id, 2);

            subgroup = ctrl.GetSubgroupByName("xxxxxxxxx");
            Assert.IsNull(subgroup);

            subgroup = ctrl.GetSubgroupByShortName("N491");
            Assert.IsNotNull(subgroup);
            Assert.AreEqual(subgroup.id, 1);

            subgroup = ctrl.GetSubgroupByShortName("xxxxx");
            Assert.IsNull(subgroup);

            object[] temp = ctrl.GetAllSubgroups();
            Assert.AreEqual(temp.Length, 4);
            Assert.AreEqual(((Subgroup)temp[3]).id, 4);
        }
    }
}
