using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.RepositoryContracts
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
    }
}
