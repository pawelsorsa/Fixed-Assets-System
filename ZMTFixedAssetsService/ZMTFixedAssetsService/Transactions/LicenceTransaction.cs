using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssets.Abstracts.Transactions;
using FixedAssetsTransactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : ILicenceTransactions
    {
        public void AddLicence(EF_ZMTdbEntities.Licence licence)
        {
            LicenceTransactions transaction = new LicenceTransactions();
            transaction.AddLicence(licence);
        }

        public void DeleteLicence(EF_ZMTdbEntities.Licence licence)
        {
            LicenceTransactions transaction = new LicenceTransactions();
            transaction.DeleteLicence(licence);
        }

        public void EditLicence(EF_ZMTdbEntities.Licence licence)
        {
            LicenceTransactions transaction = new LicenceTransactions();
            transaction.EditLicence(licence);
        }
    }
}
