using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZMTFixedAssetsService.Transactions;
using FixedAssets.Concrete.Controllers;
using EF_ZMTdbEntities;
using System.Data;
using FixedAssets.Abstracts.DbContexts;
using ZMTFixedAssetsService.Services;

namespace TransactionsTests
{
    [TestClass]
    public class LicenceUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantAddLicence()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Licence");
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                context.Context.ExecuteStoreCommand("DELETE FROM Kind");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");

                FixedAssetService transaction = new FixedAssetService();
               

                Licence licence = new Licence() { inventory_number = "xxxx", 
                                                  name = "Windows XP",
                                                  last_modified_date = DateTime.Now
                };

                transaction.AddLicence(licence);
            }
        }

        [TestMethod]
        public void CanAddLicence()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Licence");
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                context.Context.ExecuteStoreCommand("DELETE FROM Kind");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");

                FixedAssetService transaction = new FixedAssetService();
                FixedAsset asset = new FixedAsset()
                {
                    id = 2222,
                    inventory_number = "aaaa",
                    date_of_activation = DateTime.Now,
                    cassation = false
                };

                MembershipUser user = new MembershipUser()
                {
                    login = "user123",
                    email = "user@user.com",
                    creation_date = DateTime.Now,
                    is_online = false,
                    name = "Jan",
                    surname = "Kowalski",
                    is_active = true,
                    last_login_date = DateTime.Now,
                    password = "p@ssword"
                };

                Kind kind = new Kind() { name = "Oprogramowanie" };

                Licence licence = new Licence() { inventory_number = "xxxx", 
                                                  name = "Windows XP",
                                                  created_by = user.login,
                                                  MembershipUser = user,
                                                  FixedAsset = asset,
                                                  Kind = kind,
                                                  last_modified_login = user.login,
                                                  last_modified_date = DateTime.Now
                };

                transaction.AddLicence(licence);
                Assert.AreEqual(context.Context.Licences.Count(), 1);


                licence = context.Context.Licences.FirstOrDefault(x => x.inventory_number == "xxxx");
                Assert.IsNotNull(licence);
                Assert.AreEqual(licence.name, "Windows XP");
            }
        }

        [TestMethod]
        public void CanEditLicence()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Licence");
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                context.Context.ExecuteStoreCommand("DELETE FROM Kind");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");
                FixedAssetService transaction = new FixedAssetService();
                FixedAsset asset = new FixedAsset()
                {
                    id = 2222,
                    inventory_number = "aaaa",
                    date_of_activation = DateTime.Now,
                    cassation = false
                };

                MembershipUser user = new MembershipUser()
                {
                    login = "user123",
                    email = "user@user.com",
                    creation_date = DateTime.Now,
                    is_online = false,
                    name = "Jan",
                    surname = "Kowalski",
                    is_active = true,
                    last_login_date = DateTime.Now,
                    password = "p@ssword"
                };

                Kind kind = new Kind() { name = "Oprogramowanie" };

                Licence licence = new Licence()
                {
                    inventory_number = "xxxx",
                    name = "Windows XP",
                    created_by = user.login,
                    MembershipUser = user,
                    FixedAsset = asset,
                    Kind = kind,
                    last_modified_login = user.login,
                    last_modified_date = DateTime.Now
                };

                transaction.AddLicence(licence);
                Assert.AreEqual(context.Context.Licences.Count(), 1);

                kind = new Kind() { name = "Urządzenia peryferyjne" };
                context.Context.Kinds.AddObject(kind);
                context.SaveChanges();

                licence = context.Context.Licences.FirstOrDefault(x => x.inventory_number == "xxxx");
                Assert.IsNotNull(licence);
                licence.Kind = kind;
                licence.inventory_number = "vvvv";
                transaction.EditLicence(licence);

                Assert.AreEqual(context.Context.Kinds.Count(), 2);
                Assert.AreEqual(context.Context.Licences.Count(), 1);

                licence = context.Context.Licences.FirstOrDefault(x => x.inventory_number == "vvvv");
                Assert.IsNotNull(licence);
                Assert.AreEqual(licence.Kind.name, "Urządzenia peryferyjne");

            }
        }

        [TestMethod]
        public void CanDeleteLicence()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM Licence");
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                context.Context.ExecuteStoreCommand("DELETE FROM Kind");
                context.Context.ExecuteStoreCommand("DELETE FROM FixedAsset");

                FixedAssetService transaction = new FixedAssetService();
                FixedAsset asset = new FixedAsset()
                {
                    id = 2222,
                    inventory_number = "aaaa",
                    date_of_activation = DateTime.Now,
                    cassation = false
                };

                MembershipUser user = new MembershipUser()
                {
                    login = "user123",
                    email = "user@user.com",
                    creation_date = DateTime.Now,
                    is_online = false,
                    name = "Jan",
                    surname = "Kowalski",
                    is_active = true,
                    last_login_date = DateTime.Now,
                    password = "p@ssword"
                };

                Kind kind = new Kind() { name = "Oprogramowanie" };

                Licence licence = new Licence()
                {
                    inventory_number = "xxxx",
                    name = "Windows XP",
                    created_by = user.login,
                    MembershipUser = user,
                    FixedAsset = asset,
                    Kind = kind,
                    last_modified_login = user.login,
                    last_modified_date = DateTime.Now
                };

                transaction.AddLicence(licence);
                Assert.AreEqual(context.Context.Licences.Count(), 1);
                transaction.DeleteLicence(licence);
                Assert.AreEqual(context.Context.Licences.Count(), 0);
                licence = context.Context.Licences.FirstOrDefault(x => x.inventory_number == "xxxx");
                Assert.IsNull(licence);
            }
        }



    }
}


