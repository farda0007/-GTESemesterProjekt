using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.MockData
{
    public class MockProducts
    {

        private static List<Product> _products = new List<Product>()
        {
            new Product(1, "Vinyl", 199, "Hans Philip og Jens MccCoy", "Dansktop.jpg", Product.Producttype.Vinyl, false),//, "test.jpg"
			new Product(2, "Vinyl", 299, "Tupac", "Theunderground.jpg", Product.Producttype.Vinyl, false),//, "test.jpg"
			new Product(3, "Vinyl", 399, "Kendrick Lamar", "ToPimp.jpg", Product.Producttype.Vinyl, true)//"test.jpg"
        };
        public static List<Product> GetMockProducts()
        {
            return _products;
        }
    }
}
