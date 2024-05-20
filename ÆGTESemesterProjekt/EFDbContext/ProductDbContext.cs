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
                                    User ID = atll_dk; 
                                    Password = xdm5Hbp92FaecAEwyGR3; 
                                    Connect Timeout = 30; 
                                    Encrypt = True; 
                                    Trust Server Certificate = True; 
                                    Application Intent = ReadWrite; 
                                    Multi Subnet Failover = False");
            //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VinylShopDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
            //        options.UseSqlServer(@"Data Source=mssql15.unoeuro.com;
            //Initial Catalog=VinylShopDB;
            //User ID=atll_dk;
            //Password=xdm5Hbp92FaecAEwyGR3 "
            //        );
            //          
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<Repair> Repair { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
		public DbSet<Message> Messages { get; set; }
    }

}
