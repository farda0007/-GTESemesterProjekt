namespace ÆGTESemesterProjekt.Models
{
    public class Employee : User
    {
        public int EmployeeId { get; set; }

        public Employee()
        {
        }

        public Employee(string userName, string name, string password, int phone, string email) : base(userName, name, password, phone, email)
        {
            
        }
    }
}
