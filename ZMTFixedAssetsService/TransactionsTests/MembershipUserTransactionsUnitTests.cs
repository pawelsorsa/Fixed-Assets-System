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
    public class MembershipUserTransactionsUnitTests
    {
        [TestMethod]
        public void CanAddMembershipUser()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                FixedAssetService transaction = new FixedAssetService();
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

                transaction.AddMembershipUser(user);
                Assert.AreEqual(context.Context.MembershipUsers.Count(), 1);
                user = context.Context.MembershipUsers.FirstOrDefault(x => x.login == "user123");
                Assert.IsNotNull(user);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CantAddMembershipUser()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                FixedAssetService transaction = new FixedAssetService();
                MembershipUser user = new MembershipUser()
                {
                    login = "user123",
                    name = "Jan",
                    surname = "Kowalski",
                    
                };

                transaction.AddMembershipUser(user);
                Assert.AreEqual(context.Context.MembershipUsers.Count(), 1);
                user = context.Context.MembershipUsers.FirstOrDefault(x => x.login == "user123");
                Assert.IsNotNull(user);
            }
        }


        [TestMethod]
        public void CantEditMembershipUser()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                FixedAssetService transaction = new FixedAssetService();
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

                transaction.AddMembershipUser(user);
                Assert.AreEqual(context.Context.MembershipUsers.Count(), 1);
                user = context.Context.MembershipUsers.FirstOrDefault(x => x.login == "user123");
                user.email = "xxx@xxx.com";
                transaction.EditMembershipUser(user);
                user = context.Context.MembershipUsers.FirstOrDefault(x => x.email == "user@user.com");
                Assert.IsNull(user);
                Assert.AreEqual(context.Context.MembershipUsers.Count(), 1);
            }
        }

        [TestMethod]
        public void CantDeleteMembershipUser()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipUser");
                FixedAssetService transaction = new FixedAssetService();
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

                transaction.AddMembershipUser(user);
                Assert.AreEqual(context.Context.MembershipUsers.Count(), 1);
                user = context.Context.MembershipUsers.FirstOrDefault(x => x.login == "user123");
                transaction.DeleteMembershipUser(user);
                user = context.Context.MembershipUsers.FirstOrDefault(x => x.login == "user123");
                Assert.IsNull(user);
                Assert.AreEqual(context.Context.MembershipUsers.Count(), 0);
            }
        }
    }
}


