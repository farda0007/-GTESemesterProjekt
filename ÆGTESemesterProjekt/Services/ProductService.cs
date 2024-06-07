using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
	public class ProductService : IProductService
	{
        private List<Product> _products;
        private DbGenericService<Product> _genericDbService;

        public ProductService(DbGenericService<Product> genericDbService)
        {   
            _genericDbService = genericDbService;
            _products = _genericDbService.GetObjectsAsync().Result.ToList();
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
            _genericDbService.SaveObjects(_products);
        }
        public List<Product> GetProducts()
        {
            return _products;
        }
        public async Task UpdateProductAsync(Product product)
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
                        p.Description = product.Description;
                        p.IsFavourite = product.IsFavourite;
                    }
                }
                await _genericDbService.UpdateObjectAsync(product);
            
        }
        public Product DeleteProduct(int? productId)
        {
            foreach (Product product in _products)
            {
                if (product.Id == productId)
                {
                    _products.Remove(product);
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

        //Metoden NameSearch returnerer et IEnumerable<Product>, der indeholder produktet der matcher søgekriterien.
		public IEnumerable<Product> NameSearch(string str)
		{
            //Her initialiseres en tom liste
			List<Product> nameSearch = new List<Product>();
            //Gå gennem hvert product i _products
			foreach (Product product in _products)
			{
                if (str != null)
                {
                    //Både search string og ProductName bliver konverteret til lower case.
                    //Tjek om productName indeholder search string
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
                if ((minPrice == 0 && product.Price <= maxPrice) || 
                    (maxPrice == 0 && product.Price >= minPrice) || 
                    (product.Price >= minPrice && product.Price <= maxPrice))
                {
                    filterList.Add(product);
                }
            }

            return filterList;
        }
    }

}
