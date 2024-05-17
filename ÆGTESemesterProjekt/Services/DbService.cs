using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace ÆGTESemesterProjekt.Services
{
	public class DbService
	{
		//private readonly List<User> _users = new();
		//private readonly List<Message> _messages = new();

		//public Task<List<Message>> GetMessageAsync(int userId)
		//{
		//	var messages = _messages
		//		.Where(m => m.SenderId == userId || m.RecipientId == userId)
		//		.ToList();
		//	return Task.FromResult(messages);
		//	//return _context.Messages
		//	//	.Include(m => m.Sender)
		//	//	.Include(m => m.Recipient)
		//	//	.Include(m => m.Responses)
		//	//	.where(m => m.SenderId == userId || m.RecipientId == userId)
		//	//	.ToListAsync();
		//}

		//public Task<Message> GetMessageByIdAsync(int MessageId)
		//{
  //          var message = _messages.FirstOrDefault(m => m.MessageId == MessageId);
  //          return Task.FromResult(message);
  //          //return _context.Messages
  //          //	.Include(m => m.Sender)
  //          //	.Include(m => m.Recipient)
  //          //	.FirstOrDefaultAsync(m => m.MessageId == MessageId);
  //      }

		//public Task SendMessageAsync(Message message)
		//{
  //          message.MessageId = _messages.Count + 1;
  //          message.TimeStamp = DateTime.Now;
  //          _messages.Add(message);
  //          return Task.CompletedTask;
  //          //_context.Messages.Add(message);
  //          //await _context.SaveChangesAsync();
  //      }

        public async Task<List<Product>> GetProducts()
		{
			using (var context = new ProductDbContext())
			{
				return await context.Product.ToListAsync();
			}
		}
		public async Task<List<User>> GetUsers()
		{
			using (var context = new ProductDbContext())
			{
				return await context.User.ToListAsync();
			}
		}
		public async Task AddProduct(Product product)
		{
			using (var context = new ProductDbContext())
			{
				context.Product.Add(product);
				context.SaveChanges();
			}
		}
		public async Task AddUser(User user)
		{
			using (var context = new ProductDbContext())
			{
				context.User.Add(user);
				context.SaveChanges();
			}
		}
		public async Task SaveProducts(List<Product> products)
		{
			using (var context = new ProductDbContext())
			{
				foreach (Product product in products)
				{
					context.Product.Add(product);
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
					context.User.Add(user);

				}
				context.SaveChanges();
			}
		}

        
    }
}
