using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
	public interface IProductService
	{
		List<Product> GetProduct();
		void AddProduct(Product product);
        void UpdateProduct(Product product);
        Product DeleteProduct(int? productID);
        Product GetProduct(int Id);
    }
}
