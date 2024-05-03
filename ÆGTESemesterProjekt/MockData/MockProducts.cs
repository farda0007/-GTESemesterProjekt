using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.MockData
{
	public class MockProducts
	{

		private static List<Product> _products = new List<Product>()
		{
			new Product(1, "Vinyl", 5999),//, "test.jpg"
			new Product(2, "Vinyl", 5999),//, "test.jpg"
			new Product(3, "Vinyl", 5999)//"test.jpg"
        };
		public static List<Product> GetMockProducts()
		{
			return _products;
		}
	}
}
