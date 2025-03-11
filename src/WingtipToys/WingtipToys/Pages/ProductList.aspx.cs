using System;
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

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new ApplicationDbContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }
    }
}