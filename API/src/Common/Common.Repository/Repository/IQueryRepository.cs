using Common.Lists.Pagination;
using Common.Lists.Sorting;
using System.Linq.Expressions;

namespace Common.Repository.Repository
{
    public interface IQueryRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetList(CancellationToken cancellationToken);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, object>>[]? relatedProperties = null,
            Expression<Func<TEntity, bool>>? predicate = null,
            SortingDetails<TEntity>? sortingDetails = null,
            int? skip = null,
            int? take = null,
            CancellationToken cancellationToken = default);

        Task<PagedList<TEntity>> GetListByPageAsync(int pageIndex, int pageSize,
            Expression<Func<TEntity, bool>>? predicate = null,
            Expression<Func<TEntity, object>>[]? relatedProperties = null,
            SortingDetails<TEntity>? sortingDetails = null,
            CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(object key,
            Expression<Func<TEntity, object>>[]? relatedProperties = null,
            CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>>[]? relatedProperties = null,
            CancellationToken cancellationToken = default);

        Task<long> CountAsync(Expression<Func<TEntity, bool>>? predicate = null,
            CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? predicate = null,
            CancellationToken cancellationToken = default);
    }
}
