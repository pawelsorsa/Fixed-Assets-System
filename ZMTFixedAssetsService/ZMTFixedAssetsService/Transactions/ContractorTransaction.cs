using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IContractorTransactions
    {
        public void AddContractor(EF_ZMTdbEntities.Contractor contractor)
        {
            ContractorTransactions transaction = new FixedAssetsTransactions.ContractorTransactions();
            transaction.AddContractor(contractor);
        }

        public void DeleteContractor(EF_ZMTdbEntities.Contractor contractor)
        {
            ContractorTransactions transaction = new FixedAssetsTransactions.ContractorTransactions();
            transaction.DeleteContractor(contractor);
        }

        public void EditContractor(EF_ZMTdbEntities.Contractor contractor)
        {
            ContractorTransactions transaction = new FixedAssetsTransactions.ContractorTransactions();
            transaction.EditContractor(contractor);
        }
    }
}
