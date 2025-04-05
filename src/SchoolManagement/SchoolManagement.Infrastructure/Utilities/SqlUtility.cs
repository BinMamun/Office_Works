using Microsoft.Data.SqlClient;
using SchoolManagement.Domain;
using System.Data;
using System.Reflection;

namespace SchoolManagement.Infrastructure.Utilities
{
    public class SqlUtility(SqlConnection connection, SqlTransaction transaction) : ISqlUtility
    {
        private readonly SqlConnection _connection = connection;
        private readonly SqlTransaction _transaction = transaction;

        public async Task<TReturn> ExecuteScalarAsync<TReturn>(string storedProcedureName, IDictionary<string, object> parameters = null)
        {
            using var command = CreateCommand(storedProcedureName, parameters);
            var result = await command.ExecuteScalarAsync();
            return (TReturn)Convert.ChangeType(result, typeof(TReturn));
        }
        public async Task<IDictionary<string, object>> ExecuteStoredProcedureAsync(string storedProcedureName,
            IDictionary<string, object> parameters = null,
            IDictionary<string, Type> outParameters = null)
        {
            using var cmd = CreateCommand(storedProcedureName, parameters, outParameters);
            await cmd.ExecuteNonQueryAsync();

            return ExtractOutputParameters(cmd, outParameters);
        }
        public async Task<(IList<TReturn> result, IDictionary<string, object> outValues)> QueryWithStoredProcedureAsync<TReturn>(string storedProcedureName, IDictionary<string, object> parameters = null, IDictionary<string, Type> outParameters = null) where TReturn : class, new()
        {
            using var cmd = CreateCommand(storedProcedureName, parameters, outParameters);

            var list = new List<TReturn>();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var obj = new TReturn();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        var property = typeof(TReturn).GetProperty(reader.GetName(i), BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

                        if (property != null && reader[i] != DBNull.Value)
                        {
                            property.SetValue(obj, Convert.ChangeType(reader[i], property.PropertyType));
                        }
                    }
                    list.Add(obj);
                }
            }

            var outValues = ExtractOutputParameters(cmd, outParameters);
            return (list, outValues);
        }

        private SqlCommand CreateCommand(string storedProcedureName,
            IDictionary<string, object> parameters = null,
            IDictionary<string, Type> outParameters = null)
        {
            var command = _connection.CreateCommand();
            command.CommandText = storedProcedureName;
            command.CommandType = CommandType.StoredProcedure;
            command.Transaction = _transaction;

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    command
                        .Parameters
                        .AddWithValue(item.Key, item.Value ?? DBNull.Value);
                }
            }

            if (outParameters != null)
            {
                foreach (var item in outParameters)
                {

                    var outParam = new SqlParameter(item.Key, GetDbTypeFromType(item.Value))
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outParam);
                }
            }

            return command;
        }

        private SqlDbType GetDbTypeFromType(Type type)
        {
            if (type == typeof(int) ||
                type == typeof(uint) ||
                type == typeof(short) ||
                type == typeof(ushort))
                return SqlDbType.Int;
            else if (type == typeof(long) || type == typeof(ulong))
                return SqlDbType.BigInt;
            else if (type == typeof(double) || type == typeof(decimal))
                return SqlDbType.Decimal;
            else if (type == typeof(string))
                return SqlDbType.NVarChar;
            else if (type == typeof(DateTime))
                return SqlDbType.DateTime;
            else if (type == typeof(bool))
                return SqlDbType.Bit;
            else if (type == typeof(Guid))
                return SqlDbType.UniqueIdentifier;
            else if (type == typeof(char))
                return SqlDbType.NVarChar;
            else
                return SqlDbType.NVarChar;
        }

        private IDictionary<string, object> ExtractOutputParameters(SqlCommand cmd, IDictionary<string, Type> outParameters)
        {
            var result = new Dictionary<string, object>();
            if (outParameters == null) return result;

            foreach (var param in outParameters)
            {
                result[param.Key] = cmd.Parameters[param.Key].Value;
            }

            return result;
        }
    }
}
