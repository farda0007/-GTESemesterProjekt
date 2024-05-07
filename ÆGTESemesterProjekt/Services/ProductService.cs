using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
	public class ProductService : IProductService
	{
        private JsonFileService<Product> JsonFileProductService;
        private List<Product> _products;
        private DbService _dbService;

        public ProductService(JsonFileService<Product> jsonFileProductService)
        {
            JsonFileProductService = jsonFileProductService;
            //_dbService = dbService;
            //_products = MockProducts.GetMockProducts();
            _products = JsonFileProductService.GetJsonObjects().ToList();
            //JsonFileProductService.SaveJsonObjects(_products);
            //_products = _dbService.GetProducts().Result;
        }

        public ProductService()
		{


		}
		public async Task AddProductAsync(Product product)
		{
			_products.Add(product);

			//await _dbService.AddObjectAsync(item);

		}
		public List<Product> GetProduct() { return _products; }
        public void AddProduct(Product product)
        {
            _products.Add(product);
            JsonFileProductService.SaveJsonObjects(_products);

        }
        public List<Product> GetProducts()
        {
            return _products;
        }
        public void UpdateProduct(Product product)
        {
            if (product != null)
            {
                foreach (Product p in _products)
                {
                    if (p.Id == product.Id)
                    {
                        p.ProductName = product.ProductName;
                        p.Price = product.Price;
                        p.ProductImage = product.ProductImage;
                        p.ProductName = product.ProductName;
                    }
                }
                JsonFileProductService.SaveJsonObjects(_products);
            }
        }
        public Product DeleteProduct(int? productId)
        {
            foreach (Product product in _products)
            {
                if (product.Id == productId)
                {
                    _products.Remove(product);
                    JsonFileProductService.SaveJsonObjects(_products);
                    return product;
                }
            }
            return null;
        }
        public Product GetProduct(int Id)
        {
            foreach (Product product in _products)
            {
                if (Id == product.Id)
                {
                    return product;
                }
            }
            return null;
        }
    }

}
