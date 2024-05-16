using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
	public class ProductService : IProductService
	{
        private JsonFileService<Product> JsonFileProductService;
        private List<Product> _products;
        //private DbService _dbService;
        private DbGenericService<Product> _genericDbService;

        public ProductService(JsonFileService<Product> jsonFileProductService, DbGenericService<Product> genericDbService)
        {
            JsonFileProductService = jsonFileProductService;
            _genericDbService = genericDbService;
            //_products = MockProducts.GetMockProducts();
            //_products = JsonFileProductService.GetJsonObjects().ToList();
            _products = _genericDbService.GetObjectsAsync().Result.ToList();
            JsonFileProductService.SaveJsonObjects(_products);
            _genericDbService.SaveObjects(_products);
        }

        public ProductService()
		{

		}

		public async Task AddProductAsync(Product product)
		{
			_products.Add(product);
			await _genericDbService.AddObjectAsync(product);
		}
		public List<Product> GetProduct() { return _products; }
        public void AddProduct(Product product)
        {
            _products.Add(product);
            JsonFileProductService.SaveJsonObjects(_products);
            _genericDbService.SaveObjects(_products);
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
                        p.Type = product.Type;
                    }
                }
                JsonFileProductService.SaveJsonObjects(_products);
				_genericDbService.SaveObjects(_products);
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
                    _genericDbService.DeleteObjectAsync(product);
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
		public IEnumerable<Product> NameSearch(string str)
		{
			List<Product> nameSearch = new List<Product>();
			foreach (Product product in _products)
			{
                if (str != null)
                {
                    if (product.ProductName.ToLower().Contains(str.ToLower()))
                    {
                        nameSearch.Add(product);
                    }
                }
                
			}

			return nameSearch;
		}
        public IEnumerable<Product> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Product> filterList = new List<Product>();
            foreach (Product product in _products)
            {
                if ((minPrice == 0 && product.Price <= maxPrice) || (maxPrice == 0 && product.Price >= minPrice) || (product.Price >= minPrice && product.Price <= maxPrice))
                {
                    filterList.Add(product);
                }
            }

            return filterList;
        }
    }

}
