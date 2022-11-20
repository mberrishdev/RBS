
namespace Common.Repository.UnitOfWork
{
    public class EfCoreUnitOfWork : IUnitOfWork, IDisposable
    {
        private static readonly object _lock = new();
        private readonly IServiceProvider _serviceProvider;
        private EfCoreUnitOfWorkScope _currentScope;

        public EfCoreUnitOfWork(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IUnitOfWorkScope> CreateScopeAsync(CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                if (_currentScope == null || _currentScope.IsCompleted)
                {
                    _currentScope = new EfCoreUnitOfWorkScope(_serviceProvider);
                }
            }

            await _currentScope.BeginAsync(cancellationToken);

            return _currentScope;
        }

        public void Dispose()
        {
            _currentScope?.Dispose();
        }
    }
}
