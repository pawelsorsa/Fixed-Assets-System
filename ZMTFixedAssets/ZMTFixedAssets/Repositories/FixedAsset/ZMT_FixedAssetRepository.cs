using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;


namespace ZMTFixedAssets.Repositories.FixedAsset
{
    public sealed class ZMT_FixedAssetRepository : IFixedAssetRepository
    {
        public IQueryable<EF_ZMTdbEntities.FixedAsset> FixedAssets
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.FixedAssets.AsQueryable();
                }
            }
        }
    }
}
