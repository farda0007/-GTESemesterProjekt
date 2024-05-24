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
        public async Task AddOrderAsync(Order order)
        {
            _orderList.Add(order);
            await _dbService.AddObjectAsync(order);

        }
        public List<Order> GetOrders()      
        {
            return _orderList;    
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _dbService.GetObjectsAsync();
            return orders;
        }
    }
}
