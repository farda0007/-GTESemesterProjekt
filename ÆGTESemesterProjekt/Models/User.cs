using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÆGTESemesterProjekt.Models
{
    public class User
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
		public virtual ICollection<Order> Orders { get; set; }
		public User()
        {
            //UserName = "";
            //Password = "";
            //Name = "";
            //Phone = 0;
            //Email = "";
        }

        public User(int userid, string userName, string name, string password, int phone, string email)
        {
            UserId = userid;
            UserName = userName;
            Name = name;
            Password = password;
            Phone = phone;
            Email = email;
        }
    }
}
