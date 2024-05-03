using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class UserService
    {
        public List<Employee> Users { get; set; }
        private JsonFileService<Employee> UserJsonFileService;
        public User LoggedInUser { get; set; }


        public UserService(JsonFileService<Employee> UserJsonFileService)
        {
            this.UserJsonFileService = UserJsonFileService;
            //Users = MockUsers.GetUsers();
            Users = UserJsonFileService.GetJsonObjects().ToList();
            UserJsonFileService.SaveJsonObjects(Users);
            LoggedInUser = Users[0];
        }
    }
}
