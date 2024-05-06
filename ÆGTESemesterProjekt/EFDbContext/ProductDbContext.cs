using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.EFDbContext
{
	public class ProductDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ItemDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
		}

		public DbSet<Product> Items { get; set; }
		public DbSet<User> Users { get; set; }
	}

}
