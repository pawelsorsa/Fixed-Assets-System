using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;

namespace FixedAssets.Concrete.Controllers
{
    public sealed class KindController : IKindService
    {
        private IKindRepository repository;
        public KindController(IKindRepository repo)
        {
            repository = repo;
        }

        public int CountKinds()
        {
            return repository.Kinds.Count();
        }

        public Kind GetKindById(int id)
        {
            return repository.Kinds.FirstOrDefault(kind => kind.id == id);
        }

        public Kind GetKindByName(string name)
        {
            return repository.Kinds.FirstOrDefault(kind => kind.name == name);
        }

        public object[] GetAllKinds()
        {
            return repository.Kinds.ToArray();
        }


    }
}
