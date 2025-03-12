using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI;
using WingtipToys.Models;

namespace WingtipToys.Pages
{
	public partial class ProductList : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		//public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
		//{
		//	var _db = new ApplicationDbContext();
		//	IQueryable<Product> query = _db.Products;
		//	if (categoryId.HasValue && categoryId > 0)
		//	{
		//		query = query.Where(p => p.CategoryID == categoryId);
		//	}
		//	return query;
		//}
		public IList<Product> GetProducts([QueryString("id")] int? categoryId)
		{
			List<Product> products = new List<Product>();

			SqlParameter catId = new SqlParameter("@CategoryId", SqlDbType.Int)
			{
				Value = categoryId
			};

			using (SqlDataReader reader = DbHelper.ExecuteProcedureReader("GetProductsByCategory", catId))
			{
				while (reader.Read())
				{
					products.Add(new Product
					{
						ProductID = reader.GetInt32(0),
						ProductName = reader.GetString(1),
						ImagePath = reader.GetString(4),
						UnitPrice = reader.GetDouble(2),
						Description = reader.GetString(3),
						CategoryID = reader.GetInt32(5)
					});
				}
			}
			return products;
		}
	}
}