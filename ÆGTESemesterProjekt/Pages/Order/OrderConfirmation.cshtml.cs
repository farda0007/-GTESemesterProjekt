using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Order
{
    public class OrderConfirmationModel : PageModel
    {
        private ShoppingCartService _shoppingCartService;
        private UserService _userService;
        private OrderService _orderService;
        [BindProperty]
        public Models.Order Order { get; set; }
        public Models.User User { get; set; }
        public Models.Product Product { get; set; }

        public OrderConfirmationModel(ShoppingCartService shoppingCartService, UserService userService, OrderService orderService)
        {
            _shoppingCartService = shoppingCartService;
            _userService = userService;
            _orderService = orderService;
        }
        public void OnGet()
        {
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _orderService.AddObjectAsync(Order);

            }
            return RedirectToPage("/Order/OrderConfirmation");
        }
    }
}
