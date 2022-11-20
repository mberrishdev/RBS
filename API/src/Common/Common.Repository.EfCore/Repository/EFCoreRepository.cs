using Common.Lists.Sorting;
using Common.Repository.EfCore.Options;
using Common.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Repository.EfCore.Repository
{
    public class EFCoreRepository<TDbContext, TEntity> : EfCoreQueryRepository<TDbContext, TEntity>, IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        #region ctor
        public EFCoreRepository(TDbContext context, RepositoryOptions<TDbContext> repositoryOptions) : base(context, repositoryOptions)
        {
        }
        #endregion

        #region Get
        public async Task<List<TEntity>> GetListForUpdateAsync(Expression<Func<TEntity, object>>[]? relatedProperties = null,
            Expression<Func<TEntity, bool>>? predicate = null,
            SortingDetails<TEntity>? sortingDetails = null,
            int? skip = null, int? take = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = Table;
            if (relatedProperties != null)
                query = relatedProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).AsTracking();

            return await GetListAsync(query, predicate, sortingDetails, skip, take, cancellationToken);
        }

        public async Task<TEntity> GetForUpdateAsync(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>>[]? relatedProperties = null,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = Table;
            if (relatedProperties != null)
                query = relatedProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).AsTracking();
            var entity = await query.FirstOrDefaultAsync(predicate, cancellationToken);
            return entity;
        }
        #endregion

        #region Insert
        public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            //TODO Exception
            if (entity == null)
                throw new ArgumentNullException();

            await Table.AddAsync(entity, cancellationToken);

            if (!_context.Entry(entity).IsKeySet)
                await _context.SaveChangesAsync(cancellationToken);

            await SaveChanges(cancellationToken);
            return entity;
        }
        #endregion

        #region Update
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await SaveChanges(cancellationToken);
            return entity;
        }
        #endregion

        #region Delete
        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Table.Remove(entity);
            await SaveChanges(cancellationToken);
        }
        #endregion

        #region PrivateMethods
        private Task SaveChanges(CancellationToken cancellationToken)
        {
            if (_repositoryOptions.SaveChangeStrategy == SaveChangeStrategy.PerOperation)
                return _context.SaveChangesAsync(cancellationToken);

            if (_repositoryOptions.SaveChangeStrategy == SaveChangeStrategy.PerUnitOfWork
                && _context.Database.CurrentTransaction == null)
                return _context.SaveChangesAsync(cancellationToken);

            return Task.CompletedTask;
        }
        #endregion
    }
}
