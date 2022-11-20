using Common.Repository.EfCore;
using Common.Repository.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Common.Repository.UnitOfWork
{
    public class EfCoreUnitOfWorkScope : IUnitOfWorkScope
    {
        private int _index = 0;
        private (IDbContextTransaction transaction, DbContext context) _transaction;
        private readonly IServiceProvider _serviceProvider;
        private DbContext _context;

        public bool IsCompleted { get; private set; }
        public bool IsRolledBack { get; private set; }

        public EfCoreUnitOfWorkScope(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #region Begin
        public async Task BeginAsync(CancellationToken cancellationToken = default)
        {
            if (IsCompleted)
                throw new UnitOfWorkException("Unit of work scope is already completed");
            if (_index == 0)
                await BeginTransactionAsync(cancellationToken);

            _index++;
        }
        private async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            ResolveContext();
            if (HasTransactionManager(_context))
            {
                var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
                _transaction = new(transaction, _context);
            }
        }
        private void ResolveContext()
        {
            if (_serviceProvider?.GetService(AddedDbContext.GetContextType) is DbContext context)
                _context = context;
        }

        private bool HasTransactionManager(DbContext context)
        {
            return context.Database.GetService<IDbContextTransactionManager>() is not null;
        }
        #endregion

        #region Complet
        public async Task CompletAsync(CancellationToken cancellationToken = default)
        {
            if (IsRolledBack)
                throw new UnitOfWorkException("Unit of work scope is rolled back");

            if (IsCompleted)
                return;

            if (_index == 1)
            {
                await SaveChangesAsync(cancellationToken);
                await CommitTransactions(cancellationToken);
                IsCompleted = true;
            }
        }

        private async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task CommitTransactions(CancellationToken cancellationToken = default)
        {
            await _transaction.transaction.CommitAsync(cancellationToken);
            await _transaction.transaction.DisposeAsync();
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            if (!IsCompleted)
            {
                DetachAllEntities();
                RollbackTransactions();
                IsRolledBack = true;
                IsCompleted = true;
            }
        }

        private void DetachAllEntities()
        {
            var changedEntries = _context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified
                || e.State == EntityState.Deleted).ToList();

            foreach (var entry in changedEntries)
                entry.State = EntityState.Detached;
        }

        private void RollbackTransactions()
        {
            _transaction.transaction.RollbackAsync();
            _transaction.transaction.Dispose();
        }
        #endregion
    }
}
