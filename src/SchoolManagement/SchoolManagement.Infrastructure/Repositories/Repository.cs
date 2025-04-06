using SchoolManagement.Domain;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.RepositoryContracts;
using System.Reflection;

namespace SchoolManagement.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IComparable
    {
        protected readonly ISqlUtility _sqlUtility;

        protected Repository(ISqlUtility sqlUtility)
        {
            _sqlUtility = sqlUtility;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id, string storedProcedureName)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            var (result, _) = await _sqlUtility.QueryWithStoredProcedureAsync<TEntity>(storedProcedureName, parameters);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string storedProcedureName)
        {
            var (result, _) = await _sqlUtility.QueryWithStoredProcedureAsync<TEntity>(storedProcedureName);
            return result;
        }

        public async Task AddAsync(TEntity entity, string storedProcedureName)
        {
            var parameters = EntityToDictionary(entity);
            await _sqlUtility.ExecuteStoredProcedureAsync(storedProcedureName, parameters);
        }

        public async Task UpdateAsync(TEntity entity, string storedProcedureName)
        {
            var parameters = EntityToDictionary(entity);
            await _sqlUtility.ExecuteStoredProcedureAsync(storedProcedureName, parameters);
        }

        public async Task DeleteAsync(Guid id, string storedProcedureName)
        {
            var parameters = new Dictionary<string, object>
            {
                { "@Id", id }
            };

            await _sqlUtility.ExecuteStoredProcedureAsync(storedProcedureName, parameters);
        }

        protected Dictionary<string, object> EntityToDictionary(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var dictionary = new Dictionary<string, object>();

            foreach (var prop in properties)
            {
                var name = $"@{prop.Name}";
                var value = prop.GetValue(entity) ?? DBNull.Value;
                dictionary[name] = value;
            }

            return dictionary;
        }
    }
}
