using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManager.Pages
{
	public partial class AddCategory : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void btnAddCategory_Click(object sender, EventArgs e)
		{
			DbUtility.ExecuteStoredProcedure("AddCategory", new Dictionary<string, object>
			{{ "@CategoryName", txtCategoryName.Text} });
			Response.Redirect("Category.aspx");
		}
	}
}