using System.Linq.Expressions;

namespace Core.Application.Interfaces.Repositories
{
    public interface IGenericReadRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] include);
        Task<IQueryable<T>> GetAllQueryableAsync();
    }
}
