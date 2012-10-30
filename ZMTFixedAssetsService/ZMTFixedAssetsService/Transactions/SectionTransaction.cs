using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using FixedAssetsTransactions;
using FixedAssets.Abstracts.Transactions;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : ISectionTransactions
    {
        public void AddSection(EF_ZMTdbEntities.Section section)
        {
            SectionTransactions transaction = new SectionTransactions();
            transaction.AddSection(section);
        }

        public void DeleteSection(EF_ZMTdbEntities.Section section)
        {
            SectionTransactions transaction = new SectionTransactions();
            transaction.DeleteSection(section);
        }

        public void EditSection(EF_ZMTdbEntities.Section section)
        {
            SectionTransactions transaction = new SectionTransactions();
            transaction.EditSection(section);
        }
    }
}
