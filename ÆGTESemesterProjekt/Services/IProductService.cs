using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
	public interface IProductService
	{
		List<Product> GetProducts();
		Task AddProductAsync(Product product);
		void AddProduct(Product product);
        void UpdateProduct(Product product);
        Product DeleteProduct(int? productID);
        Product GetProduct(int Id);
		IEnumerable<Product> NameSearch(string str);
	}
}
