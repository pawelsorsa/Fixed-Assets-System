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
    public class SectionTest
    {
        [TestMethod]
        public void CountSections()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a=>a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" },
                new Section { id = 2, short_name = "IMZ2" },
                new Section { id = 3, short_name = "IMZ3" },
                new Section { id = 4, short_name = "IMR1" },
                new Section { id = 5, short_name = "IMR2" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            int count = ctrl.CountSections();
            Assert.IsNotNull(count);
            Assert.AreEqual(ctrl.CountSections(), 5);
        }


        [TestMethod]
        public void GetAllSections()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" },
                new Section { id = 2, short_name = "IMZ2" },
                new Section { id = 3, short_name = "IMZ3" },
                new Section { id = 4, short_name = "IMR1" },
                new Section { id = 5, short_name = "IMR2" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            object[] allSections = ctrl.GetAllSections();
            Assert.AreEqual(allSections.Length, 5);
            Assert.AreEqual(((Section)allSections[2]).short_name, "IMZ3"); 
        }

        [TestMethod]
        public void GetSectionById()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" },
                new Section { id = 2, short_name = "IMZ2" },
                new Section { id = 3, short_name = "IMZ3" },
                new Section { id = 4, short_name = "IMR1" },
                new Section { id = 5, short_name = "IMR2" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            Section temp = ctrl.GetSectionById(1);
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.id, 1);

            Section temp2 = ctrl.GetSectionById(6);
            Assert.IsNull(temp2);
        }

        [TestMethod]
        public void GetSectionByName()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "Sekcja Zgrzewania Szyn Skarżysko Kamienna" },
                new Section { id = 2, short_name = "IMZ2", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle" },
                new Section { id = 3, short_name = "IMZ3", name = "Sekcja Zgrzewania Szyn Bydgoszcz" },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko" },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            Section temp = ctrl.GetSectionByName("Sekcja Zgrzewania Szyn Kędzierzyn Koźle");
            Assert.IsNotNull(temp);
            Assert.AreEqual(((Section)temp).short_name, "IMZ2");

            Section temp2 = ctrl.GetSectionByName("Sekcja Zgrzewania Szyn Łódź");
            Assert.IsNull(temp2);
        }

        [TestMethod]
        public void GetSectionByShortName()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "Sekcja Zgrzewania Szyn Skarżysko Kamienna" },
                new Section { id = 2, short_name = "IMZ2", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle" },
                new Section { id = 3, short_name = "IMZ3", name = "Sekcja Zgrzewania Szyn Bydgoszcz" },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko" },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            Section temp = ctrl.GetSectionByShortName("IMZ3");
            Assert.IsNotNull(temp);
            Assert.AreEqual(((Section)temp).name, "Sekcja Zgrzewania Szyn Bydgoszcz");
            Assert.AreEqual(((Section)temp).id, 3);

            Section temp2 = ctrl.GetSectionByShortName("IMZ4");
            Assert.IsNull(temp2);
        }


        [TestMethod]
        public void GetSectionsByPostalCode()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "SEKCJA ZMECHANIZOWANEJ WYMIANY NAWIERZCHNI", postal_code = "31-987" },
                new Section { id = 2, short_name = "IMN", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle", postal_code = "47-224" },
                new Section { id = 3, short_name = "IMP", name = "SEKCJA ZMECHANIZOWANEJ WYMIANY PODTORZA", postal_code = "31-987" },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko", postal_code = "26-110" },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa", postal_code = "03-829" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            object[] temp = ctrl.GetSectionsByPostalCode("31-987");
            Assert.AreEqual(temp.Length, 2);
            Assert.AreEqual(((Section)temp[1]).id, 3);

            object[] temp2 = ctrl.GetSectionsByPostalCode("26-110");
            Assert.AreEqual(temp2.Length, 1);
            Assert.AreEqual(((Section)temp2[0]).id, 4);

            object[] temp3 = ctrl.GetSectionsByPostalCode("55-555");
            Assert.AreEqual(temp3.Length, 0);
        }

        [TestMethod]
        public void GetSectionsByPost()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "SEKCJA ZMECHANIZOWANEJ WYMIANY NAWIERZCHNI", post = "Kraków" },
                new Section { id = 2, short_name = "IMN", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle", post = "Kędzierzyn-Koźle" },
                new Section { id = 3, short_name = "IMP", name = "SEKCJA ZMECHANIZOWANEJ WYMIANY PODTORZA", post = "Kraków"  },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko", post = "Skarżysko-Kamienna" },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa", post = "Warszawa" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            object[] temp = ctrl.GetSectionsByPost("Warszawa");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Section)temp[0]).short_name, "IMR2");

            object[] temp2 = ctrl.GetSectionsByPost("Kraków");
            Assert.AreEqual(temp2.Length, 2);
            Assert.AreEqual(((Section)temp2[1]).short_name, "IMP");

            object[] temp3 = ctrl.GetSectionsByPost("Poznań");
            Assert.AreEqual(temp3.Length, 0);
        }

        [TestMethod]
        public void GetSectionsByLocality()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "SEKCJA ZMECHANIZOWANEJ WYMIANY NAWIERZCHNI", locality = "Kraków" },
                new Section { id = 2, short_name = "IMN", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle", locality = "Kędzierzyn-Koźle" },
                new Section { id = 3, short_name = "IMP", name = "SEKCJA ZMECHANIZOWANEJ WYMIANY PODTORZA", locality = "Kraków"  },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko", locality = "Skarżysko-Kamienna" },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa", locality = "Warszawa" },
                new Section { id = 6, short_name = "IMPR", name = "DZIAŁ PRACOWNICZY I ORGANIZACJI", locality = "Kraków" }
           
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            object[] temp = ctrl.GetSectionsByLocality("Kraków");
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Section)temp[2]).short_name, "IMPR");

            temp = ctrl.GetSectionsByLocality("Warszawa");
            Assert.AreEqual(temp.Length, 1);
            Assert.AreEqual(((Section)temp[0]).short_name, "IMR2");

            temp = ctrl.GetSectionsByLocality("Wrocław");
            Assert.AreEqual(temp.Length, 0);
        }

        [TestMethod]
        public void GetSectionByPhoneNumber()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "Sekcja Zgrzewania Szyn Skarżysko Kamienna", phone_number = "111111" },
                new Section { id = 2, short_name = "IMZ2", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle", phone_number = "222222" },
                new Section { id = 3, short_name = "IMZ3", name = "Sekcja Zgrzewania Szyn Bydgoszcz", phone_number = "333333" },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko", phone_number = "444444" },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa", phone_number = "55555" }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            Section section = ctrl.GetSectionByPhoneNumber("333333");
            Assert.IsNotNull(section);
            Assert.AreEqual(section.short_name, "IMZ3");

            section = ctrl.GetSectionByPhoneNumber("888888");
            Assert.IsNull(section);
        }

        [TestMethod]
        public void GetSectionByEmail()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "Sekcja Zgrzewania Szyn Skarżysko Kamienna", email = "imz1@plk-sa.pl" },
                new Section { id = 2, short_name = "IMZ2", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle", email = "imz2@plk-sa.pl"  },
                new Section { id = 3, short_name = "IMZ3", name = "Sekcja Zgrzewania Szyn Bydgoszcz", email = "imz3@plk-sa.pl"  },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko", email = "imr1@plk-sa.pl"  },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa", email = "imr1@plk-sa.pl"  }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            Section section = ctrl.GetSectionByEmail("imr1@plk-sa.pl");
            Assert.IsNotNull(section);
            Assert.AreEqual(section.short_name, "IMR1");

            section = ctrl.GetSectionByEmail("imz4@plk-sa.pl");
            Assert.IsNull(section);
        }

        [TestMethod]
        public void GetSectionsByStreet()
        {
            Mock<ISectionRepository> mock = new Mock<ISectionRepository>();
            mock.Setup(a => a.Sections).Returns(new Section[]
            {
                new Section { id = 1, short_name = "IMZ1" , name = "Sekcja Zgrzewania Szyn Skarżysko Kamienna", street = "Piękna 15" },
                new Section { id = 2, short_name = "IMZ2", name = "Sekcja Zgrzewania Szyn Kędzierzyn Koźle", street = "Towarowa 5"  },
                new Section { id = 3, short_name = "IMZ3", name = "Sekcja Zgrzewania Szyn Bydgoszcz", street = "Ludwikowo 2"  },
                new Section { id = 4, short_name = "IMR1", name = "Sekcja Robót Inżynieryjnych Skarżysko Kamienna", street = "Piękna 15"  },
                new Section { id = 5, short_name = "IMR2", name = "Sekcja Robót Inżynieryjnych Warszawa", street = "Poskarbińska 51"  }
            }.AsQueryable());

            SectionController ctrl = new SectionController(mock.Object);
            object[] temp = ctrl.GetSectionsByStreet("Piękna 15");
            Assert.AreEqual(temp.Length, 2);

            temp = ctrl.GetSectionsByStreet("Piękna");
            Assert.AreEqual(temp.Length, 0);

            temp = ctrl.GetSectionsByStreet("Towarowa 5");
            Assert.AreEqual(temp.Length, 1);
        }


    }
}
