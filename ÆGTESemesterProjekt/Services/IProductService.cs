using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
	public interface IProductService
	{
		List<Product> GetProduct();
		Task AddProductAsync(Product product);
		void AddProduct(Product product);
        void UpdateProduct(Product product);
        Product DeleteProduct(int? productID);
        Product GetProduct(int Id);
    }
}
