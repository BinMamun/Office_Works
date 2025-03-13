using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public static class DbUtility
{
    private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ProductDB"].ConnectionString;

    // Execute Non-Query (INSERT, UPDATE, DELETE)
    public static int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
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

    // Execute Reader (SELECT)
    public static DataTable ExecuteReader(string procedureName, params SqlParameter[] parameters)
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
}
