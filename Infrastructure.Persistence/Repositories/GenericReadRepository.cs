using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _set;

        public GenericReadRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _set = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] include)
        {
            try
            {
                var query = _set.AsQueryable();
                Include(ref query, include);

                if (predicate != null)
                    query = query.Where(predicate);

                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IQueryable<T>> GetAllQueryableAsync()
        {
            return _set;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _set.FirstOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _set.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void Include(ref IQueryable<T> query, params Expression<Func<T, object>>[] include)
        {
            if (include != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in include)
                    query = query.Include<T, object>(navigationProperty);
            }
        }
    }
}
