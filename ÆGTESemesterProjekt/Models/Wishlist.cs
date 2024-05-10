using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÆGTESemesterProjekt.Models
{
    public class Wishlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WishlistId { get; set; }

        public int userId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Wishlist()
        {
        }

        public Wishlist(User user, Product product)
        {
            User = user;
            Product = product;
        }
    }

}
