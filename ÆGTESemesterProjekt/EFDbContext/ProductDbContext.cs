using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.EFDbContext
{
	public class ProductDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VinylShopDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
		}

		public DbSet<Product> Product { get; set; }
		public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
		public DbSet<Wishlist> Wishlist { get; set; }
		public DbSet<Repair> Repair { get; set; }
    }

}
