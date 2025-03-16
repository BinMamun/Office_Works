using ProductManager.Logic;
using System;
using System.Collections.Generic;
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
			GridView1.DataSource = CategoryLogic.GetCategories();
			GridView1.DataBind();
		}

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int categoryId = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"EditCategory.aspx?categoryId={categoryId}");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int categoryId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
			DbUtility.ExecuteStoredProcedure("DeleteCategory", new Dictionary<string, object>
			{{ "@CategoryId", categoryId} });
            Load_Categories();
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCategory.aspx");
        }

		protected void gvCategory_Command(object sender, GridViewCommandEventArgs e)
		{
			var id = Convert.ToInt32(e.CommandArgument);
			if (e.CommandName == "Edit")
			{
				Response.Redirect($"EditCategory.aspx?categoryId={id}");
			}
			else if (e.CommandName == "Delete")
			{
				DbUtility.ExecuteStoredProcedure("DeleteCategory", new Dictionary<string, object>
				{
					{"@CategoryID", id }
				});
				e.Handled = true;
			}
			Load_Categories();
		}
	}
}