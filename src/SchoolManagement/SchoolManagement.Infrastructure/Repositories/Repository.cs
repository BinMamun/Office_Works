using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.RepositoryContracts;
using SchoolManagement.Domain;
using System.Reflection;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
    where TKey : IComparable
    {
        protected readonly ISqlUtility _sqlUtility;
        protected readonly string _entityName;

        public Repository(ISqlUtility sqlUtility)
        {
            _sqlUtility = sqlUtility;
            _entityName = typeof(TEntity).Name;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var parameters = new Dictionary<string, object> { { "@Id", id } };
            var (result, _) = await _sqlUtility.QueryWithStoredProcedureAsync<TEntity>($"sp_GetById_{_entityName}", parameters);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var (result, _) = await _sqlUtility.QueryWithStoredProcedureAsync<TEntity>($"sp_GetAll_{_entityName}");
            return result;
        }

        public async Task AddAsync(TEntity entity)
        {
            var parameters = EntityToDictionary(entity);
            await _sqlUtility.ExecuteStoredProcedureAsync($"sp_Add_{_entityName}", parameters);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var parameters = EntityToDictionary(entity);
            await _sqlUtility.ExecuteStoredProcedureAsync($"sp_Update_{_entityName}", parameters);
        }

        public async Task DeleteAsync(Guid id)
        {
            var parameters = new Dictionary<string, object> { { "@Id", id } };
            await _sqlUtility.ExecuteStoredProcedureAsync($"sp_Delete_{_entityName}", parameters);
        }

        private Dictionary<string, object> EntityToDictionary(TEntity entity)
        {
            return entity.GetType()
                         .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                         .ToDictionary(p => $"@{p.Name}", p => p.GetValue(entity) ?? DBNull.Value);
        }
    }

}
