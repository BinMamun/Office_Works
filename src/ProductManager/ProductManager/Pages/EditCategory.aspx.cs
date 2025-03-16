using ProductManager.Logic;
using System;
using System.Data;
using System.Web.UI;

namespace ProductManager.Pages
{
	public partial class EditCategory : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				int categoryID = Convert.ToInt32(Request.QueryString["categoryId"]);
				var dt = CategoryLogic.GetCategorybyId(categoryID);

				if (dt.Rows.Count > 0)
				{
					DataRow row = dt.Rows[0];
					hfCategoryID.Value = row["CategoryId"].ToString();
					txtCategoryName.Text = row["CategoryName"].ToString();
				}
			}
		}

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			int categoryId = Convert.ToInt32(hfCategoryID.Value);
			string categoryName = txtCategoryName.Text;

			CategoryLogic.UpdateCategory(categoryId, categoryName);
			Response.Redirect("Category.aspx");
		}
	}
}