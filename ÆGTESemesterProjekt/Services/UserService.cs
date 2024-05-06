using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class UserService
    {
        public List<User> Users { get; set; }
        private JsonFileService<User> _userJsonFileService;
        //public User LoggedInUser { get; set; }


        public UserService(JsonFileService<User> UserJsonFileService)
        {
            _userJsonFileService = UserJsonFileService;
            //Users = MockUsers.GetUsers();
            Users = UserJsonFileService.GetJsonObjects().ToList();
            UserJsonFileService.SaveJsonObjects(Users);
            //LoggedInUser = Users[0];
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


    }
}
