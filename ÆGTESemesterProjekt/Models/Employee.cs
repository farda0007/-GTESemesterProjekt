namespace ÆGTESemesterProjekt.Models
{
    public class Employee : User
    {
        public int EmployeeId { get; set; }

        public Employee()
        {
        }

        public Employee(int id, string userName, string name, string password, int phone, string email) : base(id, userName, name, password, phone, email)
        {
            EmployeeId = id;
        }
    }
}
