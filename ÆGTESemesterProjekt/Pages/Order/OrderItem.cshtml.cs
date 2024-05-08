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

        public Models.User user {  get; set; }
        public Product product { get; set; }
        public Models.Order order { get; set; } = new Models.Order();
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
            product = _productService.GetProduct(id);
            user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            product = _productService.GetProduct(id);
            user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            order.userId = user.UserId;
            order.ProductId = product.Id;
            order.Date = DateTime.Now;
            order.Count = Count;
            _orderService.AddOrder(order);
            return RedirectToPage("/Products/GetAllProducts");
        }
    }
}
