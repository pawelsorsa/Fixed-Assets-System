using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Services;

namespace ZMTFixedAssetsService.Services
{
    public partial class FixedAssetService : IKindService
    {
        public int CountKinds()
        {
            return KindController.CountKinds();
        }

        public object[] GetAllKinds()
        {
            return KindController.GetAllKinds();
        }

        public EF_ZMTdbEntities.Kind GetKindById(int id)
        {
            return KindController.GetKindById(id);
        }

        public EF_ZMTdbEntities.Kind GetKindByName(string name)
        {
            return KindController.GetKindByName(name);
        }
    }
}
