namespace ÆGTESemesterProjekt.Models
{
    public class ShoppingCart
    {
        public int UserId { get; set; }
        public List<ShoppingCart> Products { get; set; }

        public ShoppingCart()
        {
        }

        public ShoppingCart(int userId, List<ShoppingCart> products)
        {
            UserId = userId;
            Products = products;
        }
    }
}
