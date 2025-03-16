using ProductManager.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductManager.Pages
{
	public partial class EditCategory : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
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

		protected void btnUpdate_Click(object sender, EventArgs e)
		{
            
        }
	}
}