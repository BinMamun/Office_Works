using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;

namespace WingtipToys.Pages
{
	public partial class ProductDetails : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		//public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
		//{
		//    var _db = new ApplicationDbContext();
		//    IQueryable<Product> query = _db.Products;
		//    if (productId.HasValue && productId > 0)
		//    {
		//        query = query.Where(p => p.ProductID == productId);
		//    }
		//    else
		//    {
		//        query = null;
		//    }
		//    return query;
		//}

		public Product GetProduct([QueryString("productID")] int? productId)
		{
			Product product = new Product();
			SqlParameter prodID = new SqlParameter("@ProductId", SqlDbType.Int)
			{
				Value = productId
			};

			using (SqlDataReader reader = DbHelper.ExecuteProcedureReader("GetProductById", prodID))
			{
				if (reader.Read())
				{
					product.ProductID = reader.GetInt32(0);
					product.ProductName = reader.GetString(1);
					product.ImagePath = reader.GetString(2);
					product.UnitPrice = reader.GetDouble(3);
					product.Description = reader.GetString(4);
					product.CategoryID = reader.GetInt32(5);
				}
			}
			return product;
		}
	}
}