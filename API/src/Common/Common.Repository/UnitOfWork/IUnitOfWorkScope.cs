namespace Common.Repository.UnitOfWork
{
    public interface IUnitOfWorkScope : IDisposable
    {
        Task CompletAsync(CancellationToken cancellationToken = default);
    }
}
