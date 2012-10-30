using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZMTFixedAssetsService.Services;
using Ninject;
using FixedAssets.Abstracts.Transactions;
using ZMTFixedAssetsService.NinjectModules;

namespace ZMTFixedAssetsService.Transactions
{
    public partial class FixedAssetTransaction
    {
        private IKernel kernel;
        private IContractorTransactions ContractorTransactions;
        private IDeviceTransactions DeviceTransactions;
        private IFixedAssetTransactions FixedAssetTransactions;
        private IKindTransactions KindTransactions;
        private ILicenceTransactions LicenceTransactions;
        private IMembershipRoleTransactions MembershipRoleTransactions;
        private IMembershipUserTransactions MembershipUserTransactions;
        private IPeripheralDeviceTransactions PheripheralDeviceTransactions;
        private IPersonTransactions PersonTransactions;
        private ISectionTransactions SectionTransactions;
        private ISubgroupTransactions SubgroupTransactions;

        public FixedAssetTransaction()
        {
            kernel = new StandardKernel(new FixedAssetsTransactionsWithConstructorArgumentServiceModule());
            SetUpTransactions();
        }

        private void SetUpTransactions()
        {
            ContractorTransactions = kernel.Get<IContractorTransactions>();
            DeviceTransactions = kernel.Get<IDeviceTransactions>();
            FixedAssetTransactions = kernel.Get<IFixedAssetTransactions>();
            KindTransactions = kernel.Get<IKindTransactions>();
            LicenceTransactions = kernel.Get<ILicenceTransactions>();
            MembershipRoleTransactions = kernel.Get<IMembershipRoleTransactions>();
            MembershipUserTransactions = kernel.Get<IMembershipUserTransactions>();
            PheripheralDeviceTransactions = kernel.Get<IPeripheralDeviceTransactions>();
            PersonTransactions = kernel.Get<IPersonTransactions>();
            SectionTransactions = kernel.Get<ISectionTransactions>();
            SubgroupTransactions = kernel.Get<ISubgroupTransactions>();
        }

    }
}
