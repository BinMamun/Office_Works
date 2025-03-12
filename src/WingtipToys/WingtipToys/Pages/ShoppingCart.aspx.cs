using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Logic;
using WingtipToys.Models;

namespace WingtipToys.Pages
{
	public partial class ShoppingCart : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                var cartTotal = usersShoppingCart.GetTotal();
                var totalQty = usersShoppingCart.GetTotalQuantity();
                if (cartTotal > 0)
                {
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                    lblTotalQty.Text = String.Format("{0:F2}", totalQty);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    LabelTotalQtyText.Text = "";
                    lblTotalQty.Text = "";
                    ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
                }
            }
        }
		public List<CartItem> GetShoppingCartItems()
		{
			ShoppingCartActions actions = new ShoppingCartActions();
			return actions.GetCartItems();
		}

		protected void CartList_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}