using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Services
{
    public class UserDbService : DbGenericService<User>
    {
        //public async Task<List<OrderDAO>> GetOrdersByUserIdAsync(int id)
        //{
        //    List<OrderDAO> orderList = new List<OrderDAO>();

        //    using (var context = new ProductDbContext())
        //    {

        //        var orders = from order in context.Orders
        //                     join product in context.Product on order.ProductId equals product.Id
        //                     join user in context.Users on order.UserId equals user.UserId
        //                     where user.UserId == id
        //                     select new OrderDAO()
        //                     {
        //                         OrderId = order.OrderId,
        //                         Date = order.Date,
        //                         UserId = user.UserId,
        //                         UserName = user.UserName,
        //                         ItemId = product.Id,
        //                         ProductName = product.ProductName,
        //                         Price = product.Price,
        //                         Count = order.Count
        //                     };

        //        foreach (var order in orders)
        //        {
        //            orderList.Add(order);
        //        }
        //    }

        //    return orderList;
        //}
        public async Task<User> GetOrdersByUserIdAsync(int id)
        {
            User user;

            using (var context = new ProductDbContext())
            {
                user = context.User
                .Include(u => u.Orders)
                .ThenInclude(i => i.Product)
                .AsNoTracking()
                .FirstOrDefault(u => u.UserId == id);
            }
            return user;
        }

        public async Task<Wishlist> GetWishlistByUserIdAsync(int userId)
        {
            if (userId > 0)
            {
                var wishlist = await GetWishlistByUserIdAsync(userId);
                return wishlist;
                //User user;
                //using (var context = new ProductDbContext())
                //{
                //    user = context.User
                //        .Include(u => u.Wishlist)
                //        .ThenInclude(i => i.Product)
                //        .AsNoTracking()
                //        .FirstOrDefault(u => u.UserId == id);
                //}
            }
            else
            {
                throw new ArgumentException("Invalid user ID provided / No products wishlisted");
            }
        }
        public async Task<User> GetCartByUserIdAsync(int id)
        {
            User user;

            using (var context = new ProductDbContext())
            {
                user = context.User
                .Include(u => u.Orders)
                .ThenInclude(i => i.Product)
                .AsNoTracking()
                .FirstOrDefault(u => u.UserId == id);
            }
            return user;
        }
    }
}
