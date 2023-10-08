using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.DAL
{
    public interface IProvidersRepository<T>
    {
        IQueryable<T> GetAll();

        bool Delete(T entity);

        T Update(T entity);

        T Add(T entity);
        Task Add(IEnumerable<T> items);
        Task Update(IEnumerable<T> items);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
