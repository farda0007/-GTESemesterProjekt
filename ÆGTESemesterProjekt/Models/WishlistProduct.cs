


namespace ÆGTESemesterProjekt.Models
{
    public class WishlistProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public WishlistProduct(int productId, string productName, int productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }

        public WishlistProduct()
        {
        }


    }

}
