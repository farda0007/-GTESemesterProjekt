using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Services
{
    public class UserDbService : DbGenericService<User>
    {
        public async Task<Wishlist> GetWishlistByUserIdAsync(int userId)
        {
            if (userId > 0)
            {
                var wishlist = await GetWishlistByUserIdAsync(userId);
                return wishlist;
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
                .Include(u => u.CartProducts)
                .ThenInclude(i => i.Product)
                .AsNoTracking()
                .FirstOrDefault(u => u.UserId == id);
            }
            return user;
        }
    }
}
