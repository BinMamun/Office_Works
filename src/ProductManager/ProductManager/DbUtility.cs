using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public static class DbUtility
{
	private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ProductManagerDB"].ConnectionString;

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

	public static void ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters = null)
	{
		SqlParameter[] sqlParameters = parameters?
			.Select(p => new SqlParameter(p.Key, p.Value ?? DBNull.Value))
			.ToArray() ?? Array.Empty<SqlParameter>();

		ExecuteNonQuery(procedureName, sqlParameters);
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

	public static DataTable ExecuteReader(string procedureName, Dictionary<string, object> parameters = null)
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

	public static List<T> ExecuteReportReader<T>(string procedureName, Dictionary<string, object> parameters = null) where T : new()
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
