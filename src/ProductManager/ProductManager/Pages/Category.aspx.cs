using ProductManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManager.Pages
{
	public partial class Category : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Load_Categories();
			}
		}

		private void Load_Categories()
		{
			gvCategory.DataSource = CategoryLogic.GetCategories();
			gvCategory.DataBind();
		}

		protected void gvCategory_RowEditing(object sender, GridViewEditEventArgs e)
		{
			gvCategory.EditIndex = e.NewEditIndex;
			Load_Categories();
		}

		protected void gvCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			var categoryId = Convert.ToInt32(gvCategory.DataKeys[e.RowIndex].Value);
			var categoryName = ((TextBox)gvCategory.Rows[e.RowIndex].FindControl("txtCategoryName")).Text.Trim();

			CategoryLogic.UpdateCategory(categoryId, categoryName);
			gvCategory.EditIndex = -1;
			Load_Categories();
		}


		protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			int categoryId = Convert.ToInt32(gvCategory.DataKeys[e.RowIndex].Value);
			DbUtility.ExecuteStoredProcedure("DeleteCategory", new Dictionary<string, object>
			{{ "@CategoryId", categoryId} });
			Load_Categories();
		}

		protected void btnAddCategory_Click(object sender, EventArgs e)
		{
			Response.Redirect("AddCategory.aspx");
		}

		protected void gvCategory_CancelEdit(object sender, GridViewCancelEditEventArgs e)
		{
			gvCategory.EditIndex = -1;
			Load_Categories();
		}
	}
}