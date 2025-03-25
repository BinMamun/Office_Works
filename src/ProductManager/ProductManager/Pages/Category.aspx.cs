using ProductManager.Logic;
using System;
using System.Collections.Generic;
using System.Data;
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
                GetData();
                Load_Categories();
            }
        }

        private void GetData()
        {
            ViewState["tblCategory"] = CategoryLogic.GetCategories();
        }

        private void Load_Categories()
        {
            gvCategory.DataSource = ViewState["tblCategory"];
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

            UpdateGridRowAfterChange(categoryName, e.RowIndex);
            gvCategory.EditIndex = -1;
            Load_Categories();
        }

        private void UpdateGridRowAfterChange(string categoryName, int rowIndex)
        {
            DataTable dt = (DataTable)ViewState["tblCategory"];
            int tblIndex = (gvCategory.PageIndex * gvCategory.PageSize) + rowIndex;
            if (tblIndex >= 0 && tblIndex < dt.Rows.Count)
            {
                dt.Rows[tblIndex]["CategoryName"] = categoryName;
            }
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
            var categoryName = txtCategoryNameModal.Text.Trim();
            if (categoryName != null && !string.IsNullOrWhiteSpace(categoryName))
            {
                DbUtility.ExecuteStoredProcedure("AddCategory",
                    new Dictionary<string, object>
                    {
                        { "@CategoryName", txtCategoryNameModal.Text.Trim() }
                    });
            }

            Load_Categories();
        }


        protected void gvCategory_CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategory.EditIndex = -1;
            Load_Categories();
        }

    }
}
