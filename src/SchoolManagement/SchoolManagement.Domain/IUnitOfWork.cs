namespace SchoolManagement.Domain
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
