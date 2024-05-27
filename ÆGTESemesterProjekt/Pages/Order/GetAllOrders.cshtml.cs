using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Order
{
    public class GetAllOrdersModel : PageModel
    {
        private IProductService _productService;
        public List<Models.Product>? Products { get; private set; }
        public UserService UserService { get; set; }
        public OrderService OrderService { get; set; }
        public IEnumerable<Models.Order> MyOrders { get; set; }
        public List<Models.Order>? Orders { get; private set; }

        public GetAllOrdersModel(IProductService productService, OrderService orderService) //Dependency Injection
        {
            this._productService = productService;
            orderService = OrderService;
        }
        public void OnGet()
        {
            //Orders = OrderService.GetOrders();
        }
    }
}
