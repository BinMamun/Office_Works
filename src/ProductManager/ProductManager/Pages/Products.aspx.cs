using ProductManager.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManager.Pages
{
	public partial class Products : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ViewState["PageSize"] = 10;
				LoadProducts();
			}
		}

		private void LoadProducts(int pageIndex = 0)
		{
			gvProducts.DataSource = ProductLogic.GetProducts();
			gvProducts.PageSize = Convert.ToInt32(ViewState["PageSize"]);
			gvProducts.PageIndex = pageIndex;
			gvProducts.DataBind();
		}

		protected void btnAddProduct_Click(object sender, EventArgs e)
		{
			Response.Redirect("AddProduct.aspx");
		}

		protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
			{
				var ddlCategory = (DropDownList)e.Row.FindControl("ddlCategory");

				if (ddlCategory != null)
				{
					var categories = CategoryLogic.GetCategories();

					ddlCategory.DataSource = categories;
					ddlCategory.DataTextField = "CategoryName";
					ddlCategory.DataValueField = "CategoryID";
					ddlCategory.DataBind();

					// Set selected value
					var categoryId = DataBinder.Eval(e.Row.DataItem, "CategoryID").ToString();
					ddlCategory.SelectedValue = categoryId;
				}
			}
		}

		protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
		{
			//var globalPageIndex = (gvProducts.PageIndex * gvProducts.PageSize) + e.NewEditIndex;
			gvProducts.EditIndex = e.NewEditIndex;
			LoadProducts();
		}

		protected void gvProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			var id = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);
			var row = gvProducts.Rows[e.RowIndex];
			
			var productName = ((TextBox)row.FindControl("txtProductName")).Text.Trim();
			var price = decimal.Parse(((TextBox)row.FindControl("txtPrice")).Text);
			var stock = int.Parse(((TextBox)row.FindControl("txtStock")).Text);
			var categoryId = int.Parse((row.FindControl("ddlCategory") as DropDownList).SelectedValue);
			var picturePath = (row.FindControl("hfExistingImage") as HiddenField).Value;

			FileUpload fullImage = row.FindControl("fullImage") as FileUpload;
			if (fullImage.HasFile)
			{
				string fileName = $"{Guid.NewGuid()} - {Path.GetFileName(fullImage.FileName)}";
				string filePath = Server.MapPath("~/Images/") + fileName;
				fullImage.SaveAs(filePath);
				picturePath = fileName;
			}

			ProductLogic.UpdateProduct(id, productName, categoryId, price, picturePath, stock);

			gvProducts.EditIndex = -1;
			LoadProducts();
		}

		protected void gvProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			gvProducts.EditIndex = -1;
			LoadProducts();
		}

		protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			var id = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Value);
			DbUtility.ExecuteStoredProcedure("DeleteProduct", new Dictionary<string, object>
			{
				{"@ProductID", id }
			});

			LoadProducts();
		}

		protected void btnPrintProduct_Click(object sender, EventArgs e)
		{
			Response.Redirect("ProductReport.aspx");			
		}

		protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			gvProducts.PageIndex = e.NewPageIndex;
			LoadProducts(e.NewPageIndex);
		}

		//protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
		//{
		//	ViewState["PageSize"] = Convert.ToInt32(ddlPageSize.SelectedValue);
		//	gvProducts.PageIndex = 0;
		//	LoadProducts();
		//}
	}
}