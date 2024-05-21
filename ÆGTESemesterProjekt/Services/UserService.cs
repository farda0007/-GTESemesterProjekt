using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Services
{
    public class UserService
    {
        public List<User> Users { get; set; }
        private JsonFileService<User> _userJsonFileService;
        //public User LoggedInUser { get; set; }
        private UserDbService _dbService;


        public UserService(JsonFileService<User> UserJsonFileService, UserDbService dbService)
        {
            _userJsonFileService = UserJsonFileService;
            _dbService = dbService;
            //Users = MockUsers.GetUsers();
            //Users = _userJsonFileService.GetJsonObjects().ToList();
            Users = _dbService.GetObjectsAsync().Result.ToList();
            //_userJsonFileService.SaveJsonObjects(Users);
            //_dbService.SaveObjects(Users);
            //LoggedInUser = Users[0];
        }

        public async Task<User> GetUserOrders(User user)
        {
            return await _dbService.GetOrdersByUserIdAsync(user.UserId);
        }
        public async Task<Models.User> GetCartProducts(Models.User user)
        {
            using (var context = new ProductDbContext())
            {
                var userWithCart = await context.User
                    .Include(u => u.CartProducts)
                    .ThenInclude(cp => cp.Product)
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
            _userJsonFileService.SaveJsonObjects(Users);

        }
        public Models.User GetUserByUserName(string userName)
        {
            using (var context = new ProductDbContext())
            {
                var user = context.User
                    .Include(u => u.CartProducts)
                    .ThenInclude(cp => cp.Product)
                    .FirstOrDefault(u => u.UserName == userName);



                return user;
            }
        }
        public List<User> GetUsers()
        {
            return Users;
        }

    }
}
