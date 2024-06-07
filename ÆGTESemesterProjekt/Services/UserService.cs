using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Services
{
    public class UserService
    {
        public List<User> Users { get; set; }
        //public User LoggedInUser { get; set; }
        private UserDbService _dbService;


        public UserService(UserDbService dbService)
        {
            _dbService = dbService;
            Users = _dbService.GetObjectsAsync().Result.ToList();
            _dbService.SaveObjects(Users);
            //LoggedInUser = Users[0];
        }

        public async Task<Models.User> GetCartProducts(User user)
        {
            using (var context = new ProductDbContext())
            {
                
                var userWithCart = await context.User
                    //Include inkluderer CartProducts når den henter User. Det sikrer at CartProducts collection loader sammen med User. 
                    .Include(u => u.CartProducts)
                    //ThenInclude inkluderer "Product" for hvert CartProduct. Det sikrer at for hvert CartProduct, bliver det associserede "Product" også loaded.
                    .ThenInclude(u => u.Product)
                    //Forbedrer ydelsen
                    .AsNoTracking()
                    //Finder den første User der matcher det givet UserId.
                    .FirstOrDefaultAsync(u => u.UserId == user.UserId);

                return userWithCart;
            }
        }

        public async Task<Wishlist> GetUserWishlist(User user)
        {
            return await _dbService.GetWishlistByUserIdAsync(user.UserId);
        }

        public async Task AddUserAsync(User user)
        {
            Users.Add(user);
            await _dbService.AddObjectAsync(user);

        }
        public User GetUserByUserName(string userName)
        {
            foreach (User user in Users)
                if (userName == user.UserName)
                {
                    return user;
                }
            return null;
        }
        public List<User> GetUsers()
        {
            return Users;
        }
    }
}
