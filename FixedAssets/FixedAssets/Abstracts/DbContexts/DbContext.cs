using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedAssets.Abstracts.DbContexts
{
    public abstract class DbContext : IDisposable
    {
        protected string _ConnectionString;
        public abstract string ConnectionString { get; }
        public abstract void Open();
        public abstract void Close();
        public abstract void Dispose();
    }
}
