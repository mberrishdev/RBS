using RBS.Data.Repositories;
using RBS.Persistence.Database;

namespace RBS.Data.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        private IRepository<T> _baseRepository;

        public UnitOfWork(AppDbContext dbContext, IRepository<T> repository)
        {
            _baseRepository = repository;
            _dbContext = dbContext;
        }

        public IRepository<T> Repository
        {
            get { return _baseRepository; }
        }

        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();

        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
