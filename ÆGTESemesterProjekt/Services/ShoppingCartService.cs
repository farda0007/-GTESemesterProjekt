using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class ShoppingCartService
    {
        public List<ShoppingCart> _cartList;
        public DbGenericService<ShoppingCart> _dbService;

        public ShoppingCartService()
        {
        }

        public ShoppingCartService(DbGenericService<ShoppingCart> dbService)
        {
            _dbService = dbService;
            _cartList = _dbService.GetObjectsAsync().Result.ToList();
        }
            
        public void AddCart(ShoppingCart cart)
        {
            _cartList.Add(cart);
            _dbService.AddObjectAsync(cart);
        }
        public List<ShoppingCart> GetCartProducts()
        {
            return _cartList;
        }
    }
}
