using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using FixedAssets.Abstracts.Transactions;

namespace ZMTFixedAssetsService.NinjectModules
{
    public class FixedAssetsTransactionsWithConstructorArgumentServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IContractorTransactions>().To<FixedAssetsTransactions.ContractorTransactions>();
            Bind<IDeviceTransactions>().To<FixedAssetsTransactions.DeviceTransactions>();
            Bind<IFixedAssetTransactions>().To<FixedAssetsTransactions.FixedAssetTransactions>();
            Bind<IKindTransactions>().To<FixedAssetsTransactions.KindTransactions>();
            Bind<ILicenceTransactions>().To<FixedAssetsTransactions.LicenceTransactions>();
            Bind<IMembershipRoleTransactions>().To<FixedAssetsTransactions.MembershipRoleTransactions>();
            Bind<IMembershipUserTransactions>().To<FixedAssetsTransactions.MembershipUserTransactions>();
            Bind<IPeripheralDeviceTransactions>().To<FixedAssetsTransactions.PeripheralDeviceTransactions>();
            Bind<IPersonTransactions>().To<FixedAssetsTransactions.PersonTransactions>();
            Bind<ISectionTransactions>().To<FixedAssetsTransactions.SectionTransactions>();
            Bind<ISubgroupTransactions>().To<FixedAssetsTransactions.SubgroupTransactions>();
        }
    }
}
