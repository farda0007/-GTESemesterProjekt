namespace ÆGTESemesterProjekt.Models
{
    public class Customer : User
    {
        public int CustomerId { get; set; }

        public Customer()
        {
        }

        public Customer(string userName, string name, string password, int phone, string email) : base(userName, name, password, phone, email)
        {
            
        }
    }
}
