using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Order
{
    public class OrderItemModel : PageModel
    {
        public IProductService _productService;
        public UserService _userService;
        public OrderService _orderService;

        public Models.User User {  get; set; }
        public Product Product { get; set; }
        public Models.Order Order { get; set; } = new Models.Order();
        [BindProperty]
        public int Count { get; set; }

        public OrderItemModel(IProductService productService, UserService userService, OrderService orderService)
        {
            _productService = productService;
            _userService = userService;
            _orderService = orderService;
        }
        public void OnGet(int id)
        {
            Product = _productService.GetProduct(id);
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product = _productService.GetProduct(id);
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            Order.userId = User.UserId;
            Order.ProductId = Product.Id;
            Order.Date = DateTime.Now;
            Order.Count = Count;
            _orderService.AddOrder(Order);
            return RedirectToPage("/Products/GetAllProducts");
        }
    }
}
