using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Infrastructure.Utilities
{
    public class SqlUtility: ISqlUtility
    {
        private readonly string _connectionString;

        public SqlUtility(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
        }

        // Execute Non-Query (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string procedureName, params Object[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public void ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters = null)
        {
            SqlParameter[] sqlParameters = parameters?
                .Select(p => new SqlParameter(p.Key, p.Value ?? DBNull.Value))
                .ToArray() ?? Array.Empty<SqlParameter>();

            ExecuteNonQuery(procedureName, sqlParameters);
        }

        // Execute Reader (SELECT)
        public DataTable ExecuteReader(string procedureName, params Object[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable ExecuteReader(string procedureName, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters
                            .Select(p => new SqlParameter(p.Key, p.Value ?? DBNull.Value))
                            .ToArray());
                    }

                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public List<T> ExecuteReportReader<T>(string procedureName, Dictionary<string, object> parameters = null) where T : new()
        {
            List<T> model = new List<T>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters
                            .Select(p => new SqlParameter(p.Key, p.Value ?? DBNull.Value))
                            .ToArray());
                    }

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            T obj = new T();

                            foreach (var prop in typeof(T).GetProperties())
                            {
                                if (reader.HasColumn(prop.Name) && !reader
                                    .IsDBNull(reader.GetOrdinal(prop.Name)))
                                {
                                    prop.SetValue(obj, Convert.ChangeType(reader[prop.Name],
                                        prop.PropertyType));
                                }
                            }

                            model.Add(obj);
                        }
                    }
                }
            }
            return model;
        }
    }

    public static class DataReaderExtensions
    {
        public static bool HasColumn(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}