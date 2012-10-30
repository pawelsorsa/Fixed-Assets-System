using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMT_DbContext;

namespace ZMTFixedAssets.Repositories.Kind
{
    public sealed class ZMT_KindRepository : IKindRepository
    {
        public IQueryable<EF_ZMTdbEntities.Kind> Kinds
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.Kinds.AsQueryable();
                }
            }
        }
    }
}
