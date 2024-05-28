using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÆGTESemesterProjekt.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
        public decimal Price { get; set; }
        public OrderItem() 
        { 

        }

        public OrderItem(int productId, int count, decimal price)
        {
            ProductId = productId;
            Count = count;
            Price = price;
        }
    }
}
