using RBS.Data.Pagination;
using System.Linq.Expressions;

namespace RBS.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetList();
        Task<ICollection<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
        Task<IEnumerable<T>> GetAllAsyncWithIP(params Expression<Func<T, object>>[] includeProperties);
        Task<DomainPagedResult<T>> GetAllAsyncByPage(int page, Expression<Func<T, object>>[] includeProperties, List<Expression<Func<T, bool>>>? expression = null, int resultsPerPage = 10);
        Task<T> GetAsync(Expression<Func<T, object>>[] includeProperties = null, Expression<Func<T, bool>> predicate = null);
        Task<T> GetForUpdateAsync(object key);
        Task<int> CreateAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task RemoveAsync(params object[] key);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
