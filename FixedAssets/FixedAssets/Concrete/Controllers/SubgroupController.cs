using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;
using EF_ZMTdbEntities;
using FixedAssets.Abstracts.Services;


namespace FixedAssets.Concrete.Controllers
{
    public sealed class SubgroupController : ISubgroupService
    {
        private ISubgroupRepository repository;
        public SubgroupController(ISubgroupRepository repo)
        {
            repository = repo;
        }

        public int CountSubgroups()
        {
            return repository.Subgroups.Count();
        }

        public object [] GetAllSubgroups()
        {
            return repository.Subgroups.ToArray();
        }

        public Subgroup GetSubgroupById(int id)
        {
            return repository.Subgroups.FirstOrDefault(subgroup => subgroup.id == id);
        }

        public Subgroup GetSubgroupByName(string name)
        {
            return repository.Subgroups.FirstOrDefault(subgroup => subgroup.name == name);
        }

        public Subgroup GetSubgroupByShortName(string shortName)
        {
            return repository.Subgroups.FirstOrDefault(subgroup => subgroup.short_name == shortName);
        }
    }
}
