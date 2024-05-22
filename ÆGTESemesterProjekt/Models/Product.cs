using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ÆGTESemesterProjekt.Models
{
	public class Product
	{
		[Display(Name = "Produkt ID")]
		[Range(typeof(int), minimum: "0", maximum: "10000", ErrorMessage = "Id skal være mellem {1} og {2}")]
		// Muligvis skal fjernes...
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Id { get; set; }
		[Display(Name = "Produkt navn")]
		[Required(ErrorMessage = "Produktet skal have et navn")]
		[StringLength(100)]
		public string ProductName { get; set; }
		[Required(ErrorMessage = "Der skal angives en pris")]
		public decimal Price { get; set; }

		//public int Count { get; set; }
		public string Description { get; set; }
		public string ProductImage { get; set; }
		public Producttype Type { get; set; }

		[Display(Name = "Er Favorit?")]
		public bool IsFavourite { get; set; }

		public enum Producttype
		{
			CleaningTool,
			Headset,
			Radio,
			RecordPlayer,
			Speaker,
			Vinyl
		}


		public Product()
		{
			Type = 0;
			IsFavourite = false;
		}

		public Product(int id, string productName, decimal price, string description, string productImage, Producttype type, bool isFavourite)
		{
			Id = id;
			ProductName = productName;
			Price = price;
			Description = description;
			ProductImage = productImage;
			Type = type;
			IsFavourite = isFavourite;
		}
	}
}
