using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WingtipToys
{
	public static class DbHelper
	{
		public static string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		public static SqlDataReader ExecuteProcedureReader(string procedureName, params SqlParameter[] parameters)
		{
			SqlConnection conn = new SqlConnection(_connectionString);
			SqlCommand cmd = new SqlCommand(procedureName, conn)
			{
				CommandType = CommandType.StoredProcedure
			};

			if (parameters != null)
			{
				cmd.Parameters.AddRange(parameters);
			}

			conn.Open();
			return cmd.ExecuteReader(CommandBehavior.CloseConnection);
		}


		public static int ExecuteProcedureNonQuery(string procedureName, params SqlParameter[] parameters)
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

		public static object ExecuteProcedureScalar(string procedureName, params SqlParameter[] parameters)
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
					return cmd.ExecuteScalar();
				}
			}
		}
	}
}