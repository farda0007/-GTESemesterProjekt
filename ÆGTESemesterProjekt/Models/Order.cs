using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

		public int userId { get; set; }
		public User User { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "Count must be more than {1}")]
		public int Count { get; set; }

		public Order()
		{
		}

		public Order(User user, Product product)
		{
			Date = DateTime.Now;
			User = user;
			Product = product;
		}
	}
}
