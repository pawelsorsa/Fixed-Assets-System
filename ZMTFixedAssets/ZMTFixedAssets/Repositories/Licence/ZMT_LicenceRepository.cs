using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;


namespace ZMTFixedAssets.Repositories.Licence
{
    public sealed class ZMT_LicenceRepository : ILicenceRepository
    {
        public IQueryable<EF_ZMTdbEntities.Licence> Licences
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.Licences.AsQueryable();
                }
            }
        }
    }
}
