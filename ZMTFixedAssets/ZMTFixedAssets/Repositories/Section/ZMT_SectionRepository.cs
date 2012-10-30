using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;

namespace ZMTFixedAssets.Repositories.Section
{
    public sealed class ZMT_SectionRepository : ISectionRepository
    {
        public IQueryable<EF_ZMTdbEntities.Section> Sections
        {
            get 
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.Sections.AsQueryable();
                }
            }
        }
    }
}
