using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using WingtipToys.Models;

namespace WingtipToys
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<CartItem> ShoppingCartItems { get; set; }
	}
}