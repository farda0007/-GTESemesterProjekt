using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class ShoppingCartService
    {
        public List<ShoppingCart> _cartList;
        public DbGenericService<ShoppingCart> _dbService;
        public DbGenericService<Product> _productService;

        public ShoppingCartService()
        {
        }

        public ShoppingCartService(DbGenericService<ShoppingCart> dbService, DbGenericService<Product> productService)
        {
            _dbService = dbService;
            _productService = productService;
            _cartList = _dbService.GetObjectsAsync().Result.ToList();
        }
            
        public void AddCart(ShoppingCart cart)
        {
            _cartList.Add(cart);
            _dbService.AddObjectAsync(cart);
        }
        public List<ShoppingCart> GetCartProducts()
        {
            return _cartList = _dbService.GetObjectsAsync().Result.ToList();
        }
        public ShoppingCart DeleteCart(int CartId)
        {
            var cartItem = _cartList.FirstOrDefault(c => c.CartId == CartId);
            if (cartItem != null)
            {
                _cartList.Remove(cartItem);
                _dbService.DeleteObjectAsync(cartItem).Wait();
            }
            return cartItem;
        }

    }
}
