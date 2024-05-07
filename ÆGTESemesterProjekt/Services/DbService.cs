using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Services
{
	public class DbService
	{
		public async Task<List<Product>> GetProducts()
		{
			using (var context = new ProductDbContext())
			{
				return await context.Products.ToListAsync();
			}
		}
		public async Task<List<User>> GetUsers()
		{
			using (var context = new ProductDbContext())
			{
				return await context.Users.ToListAsync();
			}
		}
		public async Task AddProduct(Product product)
		{
			using (var context = new ProductDbContext())
			{
				context.Products.Add(product);
				context.SaveChanges();
			}
		}
		public async Task AddUser(User user)
		{
			using (var context = new ProductDbContext())
			{
				context.Users.Add(user);
				context.SaveChanges();
			}
		}
		public async Task SaveProducts(List<Product> products)
		{
			using (var context = new ProductDbContext())
			{
				foreach (Product product in products)
				{
					context.Products.Add(product);
					context.SaveChanges();
				}

				context.SaveChanges();
			}
		}

		public async Task SaveUsers(List<User> users)
		{
			using (var context = new ProductDbContext())
			{
				foreach (User user in users)
				{
					context.Users.Add(user);

				}
				context.SaveChanges();
			}
		}


	}
}
