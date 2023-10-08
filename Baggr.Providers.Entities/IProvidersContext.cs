using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities
{
    
        public interface IDBContext : IDisposable
        {
            DbContext Instance { get; }
        }

        public interface IProvidersContext : IDBContext
        {
            DbSet<TEntity> Set<TEntity>() where TEntity : class;

        }
}
