using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : ISubgroupService
    {
        public int CountSubgroups()
        {
           return SubgroupController.CountSubgroups();
        }

        public object[] GetAllSubgroups()
        {
            return SubgroupController.GetAllSubgroups();
        }

        public EF_ZMTdbEntities.Subgroup GetSubgroupById(int id)
        {
            return SubgroupController.GetSubgroupById(id);
        }

        public EF_ZMTdbEntities.Subgroup GetSubgroupByName(string name)
        {
            return SubgroupController.GetSubgroupByName(name);
        }

        public EF_ZMTdbEntities.Subgroup GetSubgroupByShortName(string shortName)
        {
            return SubgroupController.GetSubgroupByShortName(shortName);
        }
    }
}
