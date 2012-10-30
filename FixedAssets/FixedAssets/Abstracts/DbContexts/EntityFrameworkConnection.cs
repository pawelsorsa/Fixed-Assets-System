using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace FixedAssets.Abstracts.DbContexts
{
    public abstract class EntityFrameworkConnection : DbContext
    {
        protected ObjectContext _Context;
        public abstract void SaveChanges();
        protected abstract string CreateConnectionString();
    }
}
