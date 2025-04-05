using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.RepositoryContracts
{
    public interface IRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
        where TKey : IComparable
    {
        Task<TEntity> GetByIdAsync(Guid id, string storedProcedureName);
        Task<IEnumerable<TEntity>> GetAllAsync(string storedProcedureName);
        Task AddAsync(TEntity entity, string storedProcedureName);
        Task UpdateAsync(TEntity entity, string storedProcedureName);
        Task DeleteAsync(Guid id, string storedProcedureName);
    }
}
