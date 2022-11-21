using Common.Lists.Sorting;
using System.Linq.Expressions;

namespace Common.Repository.Repository
{
    public interface IRepository<TEntity> : IQueryRepository<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> GetListForUpdateAsync(Expression<Func<TEntity, object>>[]? relatedProperties = null,
            Expression<Func<TEntity, bool>>? predicate = null,
            SortingDetails<TEntity>? sortingDetails = null,
            int? skip = null, int? take = null,
            CancellationToken cancellationToken = default);

        Task<TEntity> GetForUpdateAsync(Expression<Func<TEntity, bool>> predicate,
           Expression<Func<TEntity, object>>[]? relatedProperties = null,
           CancellationToken cancellationToken = default);

        Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
