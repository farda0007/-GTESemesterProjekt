using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Order
{
    public class CheckOutModel : PageModel
    {
        private ShoppingCartService _shoppingCartService;
        private UserService _userService;
        private OrderService _orderService;
        public IEnumerable<Models.ShoppingCart> MyCartProducts { get; set; }
        [BindProperty]
        public Models.Order Order { get; set; }
        public Models.User User { get; set; }
        public Models.Product Product { get; set; }

        public CheckOutModel(ShoppingCartService shoppingCartService, UserService userService, OrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _userService = userService;
            _orderService = orderService;
        }

        public void OnGet()
        {
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyCartProducts = _userService.GetCartProducts(User).Result.CartProducts;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _orderService.AddObjectAsync(Order);
                await _shoppingCartService.ClearCartAsync(Order.UserId);
            }
            return RedirectToPage("/Order/OrderConfirmation", new { orderId = Order.OrderId });
        }

    }
}
