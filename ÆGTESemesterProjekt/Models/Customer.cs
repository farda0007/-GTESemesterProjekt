namespace ÆGTESemesterProjekt.Models
{
    public class Customer : User
    {
        public int CustomerId { get; set; }

        public Customer()
        {
        }

        public Customer(int id, string userName, string name, string password, int phone, string email) : base(id, userName, name, password, phone, email)
        {
            CustomerId = id;
        }
    }
}
