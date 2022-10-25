using RBS.Data.Repositories;

namespace RBS.Data.UnitOfWorks
{
    public interface IUnitOfWork<T> where T : class
    {
        IRepository<T> Repository { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
