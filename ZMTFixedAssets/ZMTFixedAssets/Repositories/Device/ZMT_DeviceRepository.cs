using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;


namespace ZMTFixedAssets.Repositories.Device
{
    public sealed class ZMT_DeviceRepository : IDeviceRepository
    {
        public IQueryable<EF_ZMTdbEntities.Device> Devices
        {
            get
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.Devices.AsQueryable();
                }
            }
        }
    }
}
