using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;

namespace ZMTFixedAssets.Repositories.Membership
{
    public sealed class ZMT_MembershipUserRepository : IMembershipUserRepository
    {

        public IQueryable<EF_ZMTdbEntities.MembershipUser> MembershipUsers
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.MembershipUsers.AsQueryable();
                }
            }
        }
    }
}
