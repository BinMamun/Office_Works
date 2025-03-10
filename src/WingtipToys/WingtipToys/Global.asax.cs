using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace WingtipToys
{
	public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
		{
            Exception ex = Server.GetLastError();

            var fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";
            var filePath = Server.MapPath($"~/App_Data/{fileName}");
            var errorMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error: {ex.Message}\nStack Trace: {ex.StackTrace}\n\n";

            File.AppendAllText(filePath, errorMessage);

            var connString = "Server=SANON;Database=WingtipToysDb; Trusted_Connection=True; TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO ErrorLogs (ErrorMessage, StackTrace) VALUES (@ErrorMessage, @StackTrace)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ErrorMessage", ex.Message);
                    cmd.Parameters.AddWithValue("@StackTrace", ex.StackTrace);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            Server.ClearError();
        }
    }
}