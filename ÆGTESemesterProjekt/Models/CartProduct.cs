namespace ÆGTESemesterProjekt.Models
{
    public class CartProduct
    {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal Total => Quantity * Price;
    }
}
