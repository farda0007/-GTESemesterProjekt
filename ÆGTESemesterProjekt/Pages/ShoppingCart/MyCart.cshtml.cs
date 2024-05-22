using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.ShoppingCart
{
    public class MyCartModel : PageModel
    {
        public UserService _userService;
        public OrderService _orderService { get; set; }
        public ShoppingCartService _shoppingCartService { get; set; }
        public IEnumerable<Models.ShoppingCart> MyCartProducts { get; set; }
        public MyCartModel(UserService userService, ShoppingCartService shoppingCartService, OrderService orderService)
        {
            _userService = userService;
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        public IActionResult OnGet()
        {
            Models.User CurrentUser = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyCartProducts = _userService.GetCartProducts(CurrentUser).Result.CartProducts;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("/Order/Checkout);");
        }
    }
}
