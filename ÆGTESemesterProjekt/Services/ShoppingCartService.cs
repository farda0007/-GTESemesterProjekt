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
        public async Task DeleteCart(int CartId)
        {
            //FirstOrDefault er LINQ metode, der returnerer det første element der opfylder en condition
            //LINQ - søger gennem _cartList, og finder det første objekt hvor CartId == CartId
            //Lambda specificerer en condition for at finde ShoppingCart objektet.
            var cartItem = _cartList.FirstOrDefault(c => c.CartId == CartId);
            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    await _dbService.UpdateObjectAsync(cartItem); 
                }
                else
                {
                    _cartList.Remove(cartItem);
                    await _dbService.DeleteObjectAsync(cartItem);
                }
            }
        }
    }
}
