using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Transactions;
using System.Data;
using EF_ZMTdbEntities;
using System.ServiceModel;

namespace FixedAssetsTransactions
{
    public sealed class DeviceTransactions : IDeviceTransactions
    {
        public void AddDevice(EF_ZMTdbEntities.Device device)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Devices.AddObject(device);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się dodać urządzenia. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void DeleteDevice(EF_ZMTdbEntities.Device device)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    context.Context.Devices.Attach(device);
                    context.Context.Devices.DeleteObject(device);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się usunąć urządzenia. Prawdopodobnie nie istnieje"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }

        public void EditDevice(EF_ZMTdbEntities.Device device)
        {
            using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
            {
                try
                {
                    Device originalDevice = context.Context.Devices.Single(p => p.id == device.id);
                    context.Context.Devices.ApplyCurrentValues(device);
                    context.SaveChanges();
                }
                catch (UpdateException)
                {
                    throw new FaultException(string.Format(
                    "Nie udało się edytować urządzenia. Popraw dane i spróbuj ponownie"));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
    }
}
