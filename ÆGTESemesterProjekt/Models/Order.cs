using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ÆGTESemesterProjekt.DAO;

namespace ÆGTESemesterProjekt.Models
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }
		
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
		public DateTime Date { get; set; }
		public decimal FinalPrice { get; set; }

		public int UserId { get; set; }
		public User User { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


        public Order()
        {
            OrderItems = new List<OrderItem>();
            Date = DateTime.Now;
        }

        public Order(int userId)
        {
            UserId = userId;
        }

        public void CalculateTotal()
        {
            FinalPrice= OrderItems.Sum(product => product.Count * product.Price);
        }
    }
}
