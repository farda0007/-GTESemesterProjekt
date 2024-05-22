using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ÆGTESemesterProjekt.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int userId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Count must be more than {1}")]
        public int Count { get; set; }
        public int ProductId { get; set; }


        public ShoppingCart()
        {
        }

        public ShoppingCart(Product product, User user)
        {
            Product = product;
            User = user;
        }
    }
}
