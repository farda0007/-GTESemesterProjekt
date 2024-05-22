namespace ÆGTESemesterProjekt.Models
{
    public class OrderItem
    {
        public int orderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        public OrderItem() { }

        public OrderItem(int productId, int count, decimal price)
        {
            ProductId = productId;
            Count = count;
            Price = price;
        }
    }
}
