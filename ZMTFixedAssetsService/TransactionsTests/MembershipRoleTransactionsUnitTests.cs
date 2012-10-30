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
    public class MembershipRoleTransactionsUnitTests
    {
        [TestMethod]
        public void CanAddMembershipRole()
        {
            using(EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipRole");
                FixedAssetService transaction = new FixedAssetService();
                MembershipRole role = new MembershipRole() {  name = "Admins" };
                transaction.AddMembershipRole(role);
                Assert.AreEqual(context.Context.MembershipRoles.Count(), 1);
                role = context.Context.MembershipRoles.FirstOrDefault(x => x.name == "Admins");
                Assert.IsNotNull(role);
            }
        }

        [TestMethod]
        public void CanDeleteMembershipRole()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipRole");
                FixedAssetService transaction = new FixedAssetService();
                MembershipRole role = new MembershipRole() { name = "Admins" };
                transaction.AddMembershipRole(role);
                Assert.AreEqual(context.Context.MembershipRoles.Count(), 1);
                role = context.Context.MembershipRoles.FirstOrDefault(x => x.name == "Admins");
                Assert.IsNotNull(role);
                transaction.DeleteMembershipRole(role);
                Assert.AreEqual(context.Context.MembershipRoles.Count(), 0);
                role = context.Context.MembershipRoles.FirstOrDefault(x => x.name == "Admins");
                Assert.IsNull(role);
            }
        }

        [TestMethod]
        public void CanEditMembershipRole()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipRole");
                FixedAssetService transaction = new FixedAssetService();
                MembershipRole role = new MembershipRole() { name = "Admins" };
                transaction.AddMembershipRole(role);
                Assert.AreEqual(context.Context.MembershipRoles.Count(), 1);
                role = context.Context.MembershipRoles.FirstOrDefault(x => x.name == "Admins");
                role.name = "Users";
                transaction.EditMembershipRole(role);
                role = context.Context.MembershipRoles.FirstOrDefault(x => x.name == "Users");
                Assert.IsNotNull(role);
                Assert.AreEqual(context.Context.MembershipRoles.Count(), 1);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CantEditMembershipRole()
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                context.Context.ExecuteStoreCommand("DELETE FROM MembershipRole");
                FixedAssetService transaction = new FixedAssetService();
                MembershipRole role = new MembershipRole() { name = "Admins" };
                transaction.EditMembershipRole(role);
            }
        }


    }
}


