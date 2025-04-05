using Microsoft.Data.SqlClient;
using SchoolManagement.Domain;
using SchoolManagement.Infrastructure.Utilities;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        private SqlUtility _sqlUtility;
        private ISqlUtility sqlUtility;

        public ISqlUtility SqlUtility => _sqlUtility;

        public UnitOfWork(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(connectionString ?? throw new InvalidOperationException("Connection string not found."));
            _connection.Open();

            _sqlUtility = new SqlUtility(_connection, _transaction);
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = (SqlTransaction)await _connection.BeginTransactionAsync();
                _sqlUtility = new SqlUtility(_connection, _transaction);
            }
        }

        public async Task<int> CommitAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
                return 1;
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                await _connection.DisposeAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }

            await _connection.DisposeAsync();
        }
    }
}
