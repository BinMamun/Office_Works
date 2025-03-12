using System;
using System.Web.UI;
using WingtipToys.Logic;

namespace WingtipToys.Pages
{
	public partial class AddToCart : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string rawId = Request.QueryString["ProductID"];
            if (!string.IsNullOrEmpty(rawId) && int.TryParse(rawId, out int productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
					usersShoppingCart.AddToCart(productId);
                }
            }
            else
            {
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
	}
}