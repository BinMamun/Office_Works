using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductManager.Logic
{
	public class ProductLogic
	{
		public static DataTable GetProducts()
		{
			return DbUtility.ExecuteReader("GetProducts");
		}

		public static DataTable GetProductsByCategory(int categoryId)
		{
			return DbUtility.ExecuteReader("GetProductsByCategory",
				new Dictionary<string, object>
				{
					{"@CategoryId", categoryId}
				});
		}

		public static void UpdateProduct(int productId, string productName, int categoryId, decimal price, string picturePath, int stock)
		{
			DbUtility.ExecuteStoredProcedure("UpdateProduct", new Dictionary<string, object>
			{
				 {"@ProductID", productId},
				 {"@ProductName", productName},
				 {"@CategoryID", categoryId},
				 {"@@Price", price},
				 {"@PicturePath ", picturePath},
				 {"@Stock ", stock}
			});
		}
	}
}