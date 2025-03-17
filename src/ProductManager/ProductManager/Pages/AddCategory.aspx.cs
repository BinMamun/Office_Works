using System;
using System.Collections.Generic;
using System.Web.UI;

namespace ProductManager.Pages
{
	public partial class AddCategory : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		protected void btnAddCategory_Click(object sender, EventArgs e)
		{
			var categoryName = txtCategoryName.Text.Trim();
			if (categoryName != null && !string.IsNullOrWhiteSpace(categoryName))
			{
				DbUtility.ExecuteStoredProcedure("AddCategory", new Dictionary<string, object> { { "@CategoryName", txtCategoryName.Text.Trim() } });
				Response.Redirect("Category.aspx");
			}
		}
	}
}