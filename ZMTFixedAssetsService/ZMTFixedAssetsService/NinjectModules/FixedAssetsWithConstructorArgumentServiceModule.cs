using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using FixedAssets.Abstracts.Repositories;

namespace ZMTFixedAssetsService.NinjectModules
{
    public class FixedAssetsWithConstructorArgumentServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IContractorRepository>().To<ZMTFixedAssets.Repositories.Contractor.ZMT_ContractorRepository>();
            Bind<IDeviceRepository>().To<ZMTFixedAssets.Repositories.Device.ZMT_DeviceRepository>();
            Bind<IFixedAssetRepository>().To<ZMTFixedAssets.Repositories.FixedAsset.ZMT_FixedAssetRepository>();
            Bind<IKindRepository>().To<ZMTFixedAssets.Repositories.Kind.ZMT_KindRepository>();
            Bind<ILicenceRepository>().To<ZMTFixedAssets.Repositories.Licence.ZMT_LicenceRepository>();
            Bind<IPeripheralDeviceRepository>().To<ZMTFixedAssets.Repositories.PeripheralDevice.ZMT_PeripheralDeviceRepository>();
            Bind<IPersonRepository>().To<ZMTFixedAssets.Repositories.Person.ZMT_PersonRepository>();
            Bind<ISectionRepository>().To<ZMTFixedAssets.Repositories.Section.ZMT_SectionRepository>();
            Bind<ISubgroupRepository>().To<ZMTFixedAssets.Repositories.Subgroup.ZMT_SubgroupRepository>();
            Bind<IMembershipRoleRepository>().To<ZMTFixedAssets.Repositories.Membership.ZMT_MembershipRoleRepository>();
            Bind<IMembershipUserRepository>().To<ZMTFixedAssets.Repositories.Membership.ZMT_MembershipUserRepository>();
        }
    }
}
