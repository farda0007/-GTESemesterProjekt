using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.MockData
{
    public class MockUsers
    {
        private static List<User> users = new List<User>()
        {
            new User("employee", "employee", "123", 60714904, "Arda@mail.com"),
            new User("Akhmed", "Akh", "Admin", 13131919, "Akhmedes@mail.com")
        };

        public static List<User> GetUsers()
        {
            return users;
        }

    }
}
