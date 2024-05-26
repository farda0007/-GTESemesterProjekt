﻿using ÆGTESemesterProjekt.EFDbContext;
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
        public async Task<List<Repair>> GetRepairs()
        {
            using (var context = new ProductDbContext())
            {
                return await context.Repair.ToListAsync();
            }
        }
        public async Task<List<Order>> GetOrders()
        {
            using (var context = new ProductDbContext())
            {
                return await context.Order.ToListAsync();
            }
        }
        public async Task<List<Wishlist>> GetWishlists()
        {
            using (var context = new ProductDbContext())
            {
                return await context.Wishlist.ToListAsync();
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
        public async Task AddRepair(Repair repair)
        {
            using (var context = new ProductDbContext())
            {
                context.Repair.Add(repair);
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
        public async Task AddWishlist(Wishlist wishlist)
        {
            using (var context = new ProductDbContext())
            {
                context.Wishlist.Add(wishlist);
                context.SaveChanges();
            }
        }
        public async Task AddOrder(Order order)
        {
            using (var context = new ProductDbContext())
            {
                context.Order.Add(order);
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
        public async Task SaveWishlists(List<Wishlist> wishlists)
        {
            using (var context = new ProductDbContext())
            {
                foreach (Wishlist wishlist in wishlists)
                {
                    context.Wishlist.Add(wishlist);

                }
                context.SaveChanges();
            }
        }
        public async Task SaveOrders(List<Order> orders)
        {
            using (var context = new ProductDbContext())
            {
                foreach (Order order in orders)
                {
                    context.Order.Add(order);

                }
                context.SaveChanges();
            }
        }
        public async Task SaveRepairs(List<Repair> repairs)
        {
            using (var context = new ProductDbContext())
            {
                foreach (Repair repair in repairs)
                {
                    context.Repair.Add(repair);

                }
                context.SaveChanges();
            }
        }
    }
}
