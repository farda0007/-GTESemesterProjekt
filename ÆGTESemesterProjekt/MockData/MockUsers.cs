using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.MockData
{
    public class MockUsers
    {
        private static List<Employee> users = new List<Employee>()
        {
            new Employee(1, "Arda", "Arda", "123", 60714904, "Arda@mail.com"),
            new Employee(1, "Akhmed", "Akh", "Admin", 13131919, "Akhmedes@mail.com")
        };

        public static List<Employee> GetUsers()
        {
            return users;
        }

    }
}
