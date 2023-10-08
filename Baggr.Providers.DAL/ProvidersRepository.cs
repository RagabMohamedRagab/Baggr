using Baggr.Providers.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.DAL
{
    public class ProvidersRepository<T> : IProvidersRepository<T> where T : class
    {
        private readonly IProvidersContext _context;

        public ProvidersRepository(IProvidersContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            try
            {
                var entities = _context.Set<T>();
                var result = entities.Add(entity);

                _context.Instance.SaveChanges();

                return result.Entity;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public IQueryable<T> GetAll()
        {
            var entities = _context.Set<T>().AsNoTracking();
            return entities;
        }

        public T Update(T entity)
        {
            try
            {
                var entities = _context.Set<T>();
                var result = entities.Update(entity);
                _context.Instance.SaveChanges();
                return result.Entity;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        
        public bool Delete(T entity)
        {
            try
            {
                var entities = _context.Set<T>();
                entities.Remove(entity);
                _context.Instance.SaveChanges();
                return true;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public async Task Add(IEnumerable<T> items)
        {
            var entities = _context.Set<T>();
            entities.AddRange(items);

           await _context.Instance.SaveChangesAsync();
        }
        public async Task Update(IEnumerable<T> items)
        {
            var entities = _context.Set<T>();
            entities.UpdateRange(items);

            await _context.Instance.SaveChangesAsync();
        }

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public IQueryable<T> TableNoTracking
        {
            get
            {
                return _context.Set<T>().AsNoTracking();
            }
        }

        #endregion
    }
}
