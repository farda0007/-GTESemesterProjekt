using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System;

namespace ÆGTESemesterProjekt.EFDbContext
{
	public class ProductDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
            options.UseSqlServer(@"Data Source = mssql15.unoeuro.com;
                            Initial Catalog = atll_dk_db_vinyl; 
                            User ID = atll_dk; 
                            Password = xdm5Hbp92FaecAEwyGR3; 
                            Connect Timeout = 30; 
                            Encrypt = False; 
                            Trust Server Certificate = False; 
                            Application Intent = ReadWrite; 
                            Multi Subnet Failover = False");                    
        }

        //public ProductDbContext(DbContextOptions<ProductDbContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<Repair> Repair { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }

}
