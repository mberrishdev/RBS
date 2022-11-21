using Microsoft.EntityFrameworkCore;

namespace Common.Repository.EfCore.Options
{
    public class RepositoryOptions<TDbContext> where TDbContext : DbContext
    {
        public SaveChangeStrategy SaveChangeStrategy { get; set; } = SaveChangeStrategy.PerUnitOfWork;
    }

    public enum SaveChangeStrategy
    {
        PerOperation,
        PerUnitOfWork
    }
}
