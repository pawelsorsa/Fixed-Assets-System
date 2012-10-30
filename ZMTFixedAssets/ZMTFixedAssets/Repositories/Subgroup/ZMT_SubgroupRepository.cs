using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;



namespace ZMTFixedAssets.Repositories.Subgroup
{
    public sealed class ZMT_SubgroupRepository : ISubgroupRepository
    {

        public IQueryable<EF_ZMTdbEntities.Subgroup> Subgroups
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.Subgroups.AsQueryable();
                }
            }
        }
    }
}
