using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.DAL
{
	public partial class UserManagement : Page
	{
		UserDAL user = new UserDAL();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
				LoadUsers();
		}

		private void LoadUsers()
		{
			GridView1.DataSource = user.GetAllUsers();
			GridView1.DataBind();
		}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            user.CreateUser(txtName.Text, txtEmail.Text, int.Parse(txtAge.Text));
            LoadUsers();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            string name = txtName.Text;
            string email = txtEmail.Text;
            int age = int.Parse(txtAge.Text);

            user.UpdateUser(id, name, email, age);
            GridView1.EditIndex = -1;
            LoadUsers();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadUsers();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            user.DeleteUser(id);
            LoadUsers();
        }
    }
}