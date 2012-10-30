using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using FixedAssets.Abstracts.Repositories;
using Ninject.Modules;
using FixedAssets.Concrete.Controllers;
using ZMTFixedAssetsService.NinjectModules;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService
    {
        private IKernel kernel;
        private IContractorRepository ContractorRepository;
        private IDeviceRepository DeviceRepository;
        private IFixedAssetRepository FixedAssetRepository;
        private IKindRepository KindRepository;
        private ILicenceRepository LicenceRepository;
        private IPersonRepository PersonRepository;
        private ISectionRepository SectionRepository;
        private ISubgroupRepository SubgroupRepository;
        private IPeripheralDeviceRepository PeripheralDeviceRepository;
        private IMembershipRoleRepository MembershipRoleRepository;
        private IMembershipUserRepository MembershipUserRepository;

        private ContractorController ContractorController;
        private DeviceController DeviceController;
        private FixedAssetController FixedAssetController;
        private KindController KindController;
        private LicenceController LicenceController;
        private PeripheralDeviceController PeripheralDeviceController;
        private PersonController PersonController;
        private SectionController SectionController;
        private SubgroupController SubgroupController;
        private MembershipRoleController MembershipRoleController;
        private MembershipUserController MembershipUserController;



        public FixedAssetService()
        {
                kernel = new StandardKernel(new FixedAssetsWithConstructorArgumentServiceModule());
                SetUpRepositories();
                SetUpControllers();

        }


        private void SetUpRepositories()
        {
            ContractorRepository = kernel.Get<IContractorRepository>();
            DeviceRepository = kernel.Get<IDeviceRepository>();
            FixedAssetRepository = kernel.Get<IFixedAssetRepository>();
            KindRepository = kernel.Get<IKindRepository>();
            LicenceRepository = kernel.Get<ILicenceRepository>();
            PeripheralDeviceRepository = kernel.Get<IPeripheralDeviceRepository>();
            PersonRepository = kernel.Get<IPersonRepository>();
            SectionRepository = kernel.Get<ISectionRepository>();
            SubgroupRepository = kernel.Get<ISubgroupRepository>();
            MembershipRoleRepository = kernel.Get<IMembershipRoleRepository>();
            MembershipUserRepository = kernel.Get<IMembershipUserRepository>();
        }

        private void SetUpControllers()
        {
            ContractorController = new ContractorController(ContractorRepository);
            DeviceController = new DeviceController(DeviceRepository);
            FixedAssetController = new FixedAssetController(FixedAssetRepository);
            KindController = new KindController(KindRepository);
            LicenceController = new LicenceController(LicenceRepository);
            PeripheralDeviceController = new PeripheralDeviceController(PeripheralDeviceRepository);
            PersonController = new PersonController(PersonRepository);
            SectionController = new SectionController(SectionRepository);
            SubgroupController = new SubgroupController(SubgroupRepository);
            MembershipRoleController = new MembershipRoleController(MembershipRoleRepository);
            MembershipUserController = new MembershipUserController(MembershipUserRepository, MembershipRoleController);
        }
    }

    
}
