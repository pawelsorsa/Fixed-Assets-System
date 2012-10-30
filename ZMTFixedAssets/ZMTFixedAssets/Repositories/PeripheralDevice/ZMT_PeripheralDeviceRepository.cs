using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;


namespace ZMTFixedAssets.Repositories.PeripheralDevice
{
    public sealed class ZMT_PeripheralDeviceRepository : IPeripheralDeviceRepository
    {
        public IQueryable<EF_ZMTdbEntities.PeripheralDevice> PeripheralDevices
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.PeripheralDevices.AsQueryable();
                }
            }
        }
    }
}
