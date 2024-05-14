using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class ShoppingCartService
    {
        private List<ShoppingCart> _cartProducts;
        private DbGenericService<ShoppingCart> _dbService;

        public ShoppingCartService(DbGenericService<ShoppingCart> dbService)
        {
            _dbService = dbService;
            _cartProducts = _dbService.GetObjectsAsync().Result.ToList();
        }

        public void AddCardProduct(ShoppingCart cart)
        {
            _cartProducts.Add(cart);
            _dbService.AddObjectAsync(cart);
        }
    }
}
