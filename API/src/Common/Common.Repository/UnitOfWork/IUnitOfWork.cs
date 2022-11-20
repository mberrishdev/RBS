namespace Common.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<IUnitOfWorkScope> CreateScopeAsync(CancellationToken cancellationToken = default);
    }
}
