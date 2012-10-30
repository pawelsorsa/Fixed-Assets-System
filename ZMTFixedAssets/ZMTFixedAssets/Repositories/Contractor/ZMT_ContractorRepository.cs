using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;

namespace ZMTFixedAssets.Repositories.Contractor
{
    public sealed class ZMT_ContractorRepository : IContractorRepository
    {
        public IQueryable<EF_ZMTdbEntities.Contractor> Contractors
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.Contractors.AsQueryable();
                }
            }
        }
    }
}
