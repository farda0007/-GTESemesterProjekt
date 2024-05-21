using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class OrderService : DbGenericService<Order>
    {
        public List<Order> _orderList;
        public DbGenericService<Order> _dbService;

        public OrderService()
        { 
        }
        public OrderService(DbGenericService<Order> dbService)
        {
            _dbService = dbService;
            _orderList = _dbService.GetObjectsAsync().Result.ToList();
        }
        public void AddOrder(Order order)
        {
            _orderList.Add(order);
            _dbService.AddObjectAsync(order);
        }
        public List<Order> GetOrders()
        {
            return _orderList;    
        }
        public async Task CreateOrderFromCartAsync(int userId, List<ShoppingCart> cartItems)
        {
            var order = new Order
            {
                userId = userId,
                OrderItems = cartItems.Select(c => new OrderItem
                {
                    ProductId = c.ProductId,
                    Count = c.Count,
                    Price = c.Product.Price
                }).ToList(),
                Date = DateTime.Now
            };

            AddOrder(order);
            await _dbService.AddObjectAsync(order);
        }
    }
}
