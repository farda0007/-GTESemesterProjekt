using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;

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
            _dbService.SaveObjects(Users);
            //LoggedInUser = Users[0];
        }

        public async Task<User> GetUserOrders(User user)
        {
            return await _dbService.GetOrdersByUserIdAsync(user.UserId);
        }
        public async Task<User> GetCartProducts(User user)
        {
            return await _dbService.GetCartByUserIdAsync(user.UserId);
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
