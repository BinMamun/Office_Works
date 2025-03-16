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
			if (!IsPostBack)
			{
				Load_Products();
			}
		}

		private void Load_Products()
		{
			gvProducts.DataSource = ProductLogic.GetProducts();
			gvProducts.DataBind();
		}

		protected void btnAddProduct_Click(object sender, EventArgs e)
		{
			Response.Redirect("AddProduct.aspx");
		}

		//protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
		//{
		//	var id = Convert.ToInt32(gvProducts.DataKeys[e.NewEditIndex].Value);
		//	Response.Redirect($"EditProduct.aspx?productId={id}");
		//}


		//protected void gvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
		//{
		//	var id = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);
		//	DbUtility.ExecuteStoredProcedure("DeleteProduct", new Dictionary<string, object>
		//	{
		//		{"@ProductID", id }
		//	});

		//	Load_Products();
		//}

		protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			var id = Convert.ToInt32(e.CommandArgument);
			if (e.CommandName == "Edit")
			{
				Response.Redirect($"EditProduct.aspx?productId={id}");
			}
			else if (e.CommandName == "Delete")
			{
				DbUtility.ExecuteStoredProcedure("DeleteProduct", new Dictionary<string, object>
				{
					{"@ProductID", id }
				});
				e.Handled = true;
			}
			Load_Products();
		}
	}
}