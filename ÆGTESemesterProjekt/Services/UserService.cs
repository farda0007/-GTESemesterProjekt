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
        private DbGenericService<User> _dbService;
        private UserDbService _userDbService;


        public UserService(JsonFileService<User> UserJsonFileService, UserDbService userDbService, DbGenericService<User> dbService)
        {
            _userJsonFileService = UserJsonFileService;
            _dbService = dbService;
            _userDbService = userDbService;
            //Users = MockUsers.GetUsers();
            Users = UserJsonFileService.GetJsonObjects().ToList();
            UserJsonFileService.SaveJsonObjects(Users);
            _dbService.SaveObjects(Users);
            //LoggedInUser = Users[0];
        }

        public async Task<User> GetUserOrders(User user)
        {
            return await _userDbService.GetOrdersByUserIdAsync(user.UserId);
        }

        public async Task AddUserAsync(User user)
        {
            Users.Add(user);
            //await _dbService.AddObjectAsync(user);
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
