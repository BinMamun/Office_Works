using ProductManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManager.Pages
{
	public partial class Products : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Load_Products()
		{
			gvProducts.DataSource = ProductLogic.GetProducts();
			gvProducts.DataBind();
		}
	}
}