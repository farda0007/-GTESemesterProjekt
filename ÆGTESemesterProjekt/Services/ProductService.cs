﻿using ÆGTESemesterProjekt.MockData;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
	public class ProductService : IProductService
	{
        private List<Product> _products;
        //private DbService _dbService;
        private DbGenericService<Product> _genericDbService;

        public ProductService(DbGenericService<Product> genericDbService)
        {   
            _genericDbService = genericDbService;
            //_products = MockProducts.GetMockProducts();
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
                        p.Description = product.Description;
                        p.IsFavourite = product.IsFavourite;
                    }
                }
                await _genericDbService.UpdateObjectAsync(product);
            }
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
