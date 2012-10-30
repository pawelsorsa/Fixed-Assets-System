using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EF_ZMTdbEntities;
using Moq;
using FixedAssets.Abstracts.Repositories;
using ZMTFixedAssets.Repositories.Person;
using FixedAssets.Concrete.Controllers;


namespace ZMTFixedAssetsTestProject
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void GetAllPersons()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a=>a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            Object [] array = ctrl.GetAllPersons();

            Assert.IsNotNull(array);
            Assert.AreEqual(array.Length, 10);
            Assert.AreEqual(((Person)array[4]).name, "Dawid");
            Assert.AreEqual(((Person)array[9]).surname, "Jakubowski");
        }

        [TestMethod]
        public void CountAllPersons()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            
            int count = ctrl.CountPersons();

            Assert.IsNotNull(count);
            Assert.AreEqual(count, 10); 
        }

        [TestMethod]
        public void GetPersonByEmail()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski", email = "j.kowalski@plk-sa.pl" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki", email = "p.barwicki@plk-sa.pl" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski", email = "r.michalski@plk-sa.pl" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            Person person = ctrl.GetPersonByEmail("p.barwicki@plk-sa.pl");
            Assert.AreEqual(person.name, "Paweł");
            Assert.AreEqual(person.surname, "Barwicki");
            Assert.AreEqual(person.email, "p.barwicki@plk-sa.pl");

            Person person2 = ctrl.GetPersonByEmail("xxxxxxxxx");
            Assert.IsNull(person2);
        }


        [TestMethod]
        public void GetPersonById()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
           
            Person temp = ctrl.GetPersonById(5);
            Assert.AreEqual(temp.name, "Dawid");
            Assert.AreEqual(temp.surname, "Kowalczyk");

            Person temp2 = ctrl.GetPersonById(22);
            Assert.IsNull(temp2);

        }


        [TestMethod]
        public void GetPersonByPhone()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski", phone_number2 = 515765265 },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki", phone_number2 = 786123543 },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            Person temp = ctrl.GetPersonByPhone(786123543);
            Assert.IsNotNull(temp);
            Assert.AreEqual(temp.id, 6);

            Person temp2 = ctrl.GetPersonByPhone(11111111);
            Assert.IsNull(temp2);
            
        }

        [TestMethod]
        public void GetPersonsByName()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            object[] temp = ctrl.GetPersonsByName("Paweł");
            Assert.AreEqual(temp.Length, 2);

            object[] temp2 = ctrl.GetPersonsByName("Zbigniew");
            Assert.AreEqual(temp2.Length, 0);
        }

        [TestMethod]
        public void GetPersonsBySurname()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            object[] temp = ctrl.GetPersonsBySurname("Jelonek");
            Assert.AreEqual(temp.Length, 2);
            object[] temp2 = ctrl.GetPersonsBySurname("Dominikowski");
            Assert.AreEqual(temp2.Length, 0);
            object[] temp3 = ctrl.GetPersonsBySurname("Jakubowski");
            Assert.AreEqual(temp3.Length, 1);
        }

        [TestMethod]
        public void GetPersonsByNameAndSurname()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalski" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Jan", surname = "Kowalski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            
            object [] temp = ctrl.GetPersonsByNameAndSurname("Jan", "Kowalski");
            Assert.AreEqual(temp.Length, 2);
            object[] temp2 = ctrl.GetPersonsByNameAndSurname("Adam", "Nowak");
            Assert.AreEqual(temp2.Length, 0);
            object[] temp3 = ctrl.GetPersonsByNameAndSurname("Dawid", "Kowalski");
            Assert.AreEqual(temp3.Length, 1);
        }


        [TestMethod]
        public void GetPersonsWithPhone()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski", phone_number2 = 781784372},
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki" },
                new Person { id = 4, name = "Michał", surname = "Jelonek", phone_number2 = 781764231 },
                new Person { id = 5, name = "Dawid", surname = "Kowalski" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski" },
                new Person { id = 10, name = "Jan", surname = "Kowalski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            object [] temp = ctrl.GetPersonsWithComPhone();
            Assert.AreEqual(temp.Length, 2);
        }

        [TestMethod]
        public void GetPersonsWithEmail()
        {
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski", email = "j.kowalski@plk-sa.pl" },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki", email = "p.barwicki@plk-sa.pl" },
                new Person { id = 4, name = "Michał", surname = "Jelonek" },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk" },
                new Person { id = 6, name = "Emil", surname = "Kopycki" },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski", email = "r.michalski@plk-sa.pl" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            object[] temp = ctrl.GetPersonsWithEmail();
            Assert.AreEqual(temp.Length, 3);
            Assert.AreEqual(((Person)temp[1]).surname, "Barwicki");

        }

        [TestMethod]
        public void GetPersonsBySection()
        {
            Section sekcja = new Section() { name = "Sekcja", id = 1 };
            Mock<IPersonRepository> mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.Persons).Returns(new Person[]
            {
                new Person { id = 1, name = "Jan", surname = "Kowalski", email = "j.kowalski@plk-sa.pl", id_section = sekcja.id },
                new Person { id = 2, name = "Kamil", surname = "Nowak" },
                new Person { id = 3, name = "Paweł", surname = "Barwicki", email = "p.barwicki@plk-sa.pl" },
                new Person { id = 4, name = "Michał", surname = "Jelonek", id_section = sekcja.id },
                new Person { id = 5, name = "Dawid", surname = "Kowalczyk", id_section = sekcja.id },
                new Person { id = 6, name = "Emil", surname = "Kopycki", id_section = sekcja.id },
                new Person { id = 7, name = "Adam", surname = "Fugiel" },
                new Person { id = 8, name = "Jan", surname = "Jelonek" },
                new Person { id = 9, name = "Rafał", surname = "Michalski", email = "r.michalski@plk-sa.pl" },
                new Person { id = 10, name = "Paweł", surname = "Jakubowski" }
            }.AsQueryable());

            PersonController ctrl = new PersonController(mock.Object);
            object[] temp = ctrl.GetPersonsBySection(sekcja.id);
            Assert.AreEqual(temp.Length, 4);
            Assert.AreEqual(((Person)temp[2]).surname, "Kowalczyk");

            object[] temp2 = ctrl.GetPersonsBySection(2);
            Assert.AreEqual(temp2.Length, 0);

        }


    }
}
