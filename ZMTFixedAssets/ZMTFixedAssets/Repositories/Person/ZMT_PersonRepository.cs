using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixedAssets.Abstracts.Repositories;


namespace ZMTFixedAssets.Repositories.Person
{
    public sealed class ZMT_PersonRepository : IPersonRepository
    {
        public IQueryable<EF_ZMTdbEntities.Person> Persons
        {
            get 
            {
                using (EF_ZMT_DbContext.EF_ZMT_DbContext context = new EF_ZMT_DbContext.EF_ZMT_DbContext())
                {
                    return context.Context.People.AsQueryable(); 
                }
            }
        }
    }
}
