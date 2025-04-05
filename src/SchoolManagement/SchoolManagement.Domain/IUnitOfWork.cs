namespace SchoolManagement.Domain
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task BeginTransactionAsync();
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
