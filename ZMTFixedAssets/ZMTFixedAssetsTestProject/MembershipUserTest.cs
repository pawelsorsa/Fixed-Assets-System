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
    public class MembershipUserTest
    {

        [TestMethod]
        public void MembershipTest()
        {
            Mock<IMembershipUserRepository> mock = new Mock<IMembershipUserRepository>();
            mock.Setup(a => a.MembershipUsers).Returns(new MembershipUser[]
            {
                new MembershipUser { login = "janek", name = "Jan" },
                new MembershipUser { login = "marianek", name = "Marian" },
                new MembershipUser { login = "kamilek", name = "Kamil" },
                new MembershipUser { login = "dawidek", name = "Dawid" },
                new MembershipUser { login = "pawełek", name = "Paweł" }
            }.AsQueryable());

            Mock<IMembershipRoleRepository> mock_role = new Mock<IMembershipRoleRepository>();
            mock_role.Setup(a => a.MembershipRoles).Returns(new MembershipRole[]
            {
                new MembershipRole { id = 1, name = "Admins" },
                new MembershipRole { id = 2, name = "Users" },
                new MembershipRole { id = 3, name = "Online" },
                new MembershipRole { id = 4, name = "Persons" },
                new MembershipRole { id = 5, name = "Contracts" },
            }.AsQueryable());

            MembershipRoleController ctrl_role =  new MembershipRoleController(mock_role.Object);
            MembershipUserController ctrl_user = new MembershipUserController(mock.Object, ctrl_role);
            object [] temp = ctrl_user.GetAllUsers();
            Assert.AreEqual(temp.Length, 5);

            temp = ctrl_role.GetAllRoles();
            Assert.AreEqual(temp.Length, 5);

            MembershipRole temp_role = ctrl_role.GetRoleById(3);
            Assert.AreEqual(temp_role.name, "Online");
            temp_role = ctrl_role.GetRoleById(6);
            Assert.IsNull(temp_role);

            MembershipUser temp_user = ctrl_user.GetUserByLogin("kamilek");
            Assert.IsNotNull(temp_user);
            Assert.AreEqual(temp_user.name, "Kamil");

            temp_user = ctrl_user.GetUserByLogin("xxxxx");
            Assert.IsNull(temp_user);

            bool sprawdz = ctrl_user.IsUserInRole("xxxxxxxx", "xxxxxxxxxx");
            Assert.AreEqual(sprawdz, false);

        }



    }
}
