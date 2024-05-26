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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _orderService.AddOrderAsync(Order);
            await _shoppingCartService.ClearCartAsync(Order.UserId);
            return RedirectToPage("/Order/OrderConfirmation", new { orderId = Order.OrderId });
        }

        // this shit dont work bro damn
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
        //    MyCartProducts = _shoppingCartService.GetCartProducts();

        //    Order = new Models.Order
        //    {
        //        UserId = User.UserId,
        //        User = User,
        //        OrderItems = new List<OrderItem>()
        //    };

        //    foreach (var cartItem in MyCartProducts)
        //    {
        //        Order.OrderItems.Add(new OrderItem
        //        {
        //            ProductId = cartItem.ProductId,
        //            Product = cartItem.Product,
        //            Count = cartItem.Count
        //        });
        //    }

        //    await _orderService.AddOrderAsync(Order);
        //    await _shoppingCartService.ClearCartAsync(User.UserId);

        //    return RedirectToPage("/Order/OrderConfirmation", new { orderId = Order.OrderId });
        //}
    }
}
