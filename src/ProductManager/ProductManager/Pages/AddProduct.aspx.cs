using ProductManager.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManager.Pages
{
	public partial class AddProduct : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var categories = CategoryLogic.GetCategories();

			ddlCategories.DataSource = categories;
			ddlCategories.DataTextField = "CategoryName";
			ddlCategories.DataValueField = "CategoryID";
			ddlCategories.DataBind();

			//ddlCategories.Items.Insert(0, new ListItem("--Select Category--", "0"));
		}

		protected void btnAddProduct_Click(object sender, EventArgs e)
		{
			string imagePath = "";
			if (ProductImageFile.HasFile)
			{
				string filename = Path.GetFileName(ProductImageFile.PostedFile.FileName);
				imagePath = "Images/" + filename;
				ProductImageFile.SaveAs(Server.MapPath("~/" + imagePath));
			}

			var parameters = new Dictionary<string, object>
			{
				{ "@ProductName",  txtProductName.Text},
				{ "@CategoryID",  ddlCategories.SelectedValue},
				{"@Price", decimal.Parse(txtPrice.Text) },
				{"@PicturePath", imagePath },
				{"@Stock", int.Parse(txtStock.Text)}

			};

			DbUtility.ExecuteStoredProcedure("AddProduct", parameters);
			Response.Redirect("Products.aspx");
		}
	}
}