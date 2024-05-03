using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÆGTESemesterProjekt.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        [Required(ErrorMessage = "Der skal angives et ID til User")]
        [Range(typeof(int), minimum: "0", maximum: "100000", ErrorMessage = "ID skal være mellem {1} og {2}")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public int Phone { get; set; }
        public string Email { get; set; }
        public User()
        {
            UserName = "";
            Password = "";
            Name = "";
            Phone = 0;
            Email = "";
        }

        public User(string userName, string name, string password, int phone, string email)
        {
            UserName = userName;
            Name = name;
            Password = password;
            Phone = phone;
            Email = email;
        }
    }
}
