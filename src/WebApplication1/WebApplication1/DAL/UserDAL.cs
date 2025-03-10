using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.DAL
{
    public class UserDAL
    {
        private string connStr = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;

        public DataTable GetAllUsers()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var sql = new SqlCommand("SELECT * FROM Users", conn);
                var da = new SqlDataAdapter(sql);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void CreateUser(string name, string email, int age)
        {
            using(var conn = new SqlConnection(connStr))
            {
                var sql = new SqlCommand("INSERT INTO Users VALUES(@xName, @xEmail, @xAge)", conn);
                sql.Parameters.AddWithValue("@xName", name);
                sql.Parameters.AddWithValue("@xEmail", email);
                sql.Parameters.AddWithValue("@xAge", age);
                conn.Open();
                sql.ExecuteNonQuery();
            }
        }

        public void UpdateUser(int id, string name, string email, int age)
        {
            using (var conn = new SqlConnection(connStr))
            {
                var sql = new SqlCommand("UPDATE Users SET Name=@xName, Email=@xEmail, Age=@xAge WHERE Id=@xId", conn);
                sql.Parameters.AddWithValue("@xId", id);
                sql.Parameters.AddWithValue("@xName", name);
                sql.Parameters.AddWithValue("@xEmail", email);
                sql.Parameters.AddWithValue("@xAge", age);
                conn.Open();
                sql.ExecuteNonQuery();
            }
        }

        public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE Id=@xId", conn);
                cmd.Parameters.AddWithValue("@xId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}