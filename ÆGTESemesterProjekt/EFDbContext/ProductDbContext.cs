using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.EFDbContext
{
	public class ProductDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(@"Data Source=mssql15.unoeuro.com;Initial Catalog=atll_dk_db_vinyl_database;User ID=atll_dk;Password=********;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
	}

}
