using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.ShoppingCart
{
    public class MyCartModel : PageModel
    {
        [BindProperty]
        public string DiscountCode { get; set; }
        [BindProperty]
        public decimal Totalprice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public bool DiscountApplied { get; set; }

        private readonly UserService _userService;
        private readonly OrderService _orderService;
        private readonly ShoppingCartService _shoppingCartService;
        public IEnumerable<Models.ShoppingCart> MyCartProducts { get; set; }

        public MyCartModel(UserService userService, ShoppingCartService shoppingCartService, OrderService orderService)
        {
            _userService = userService;
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        public IActionResult OnGet()
        {
            var currentUser = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyCartProducts = _userService.GetCartProducts(currentUser).Result.CartProducts;
            Totalprice = MyCartProducts.Sum(product => product.Count * (product.Product?.Price ?? 0));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyCartProducts = _userService.GetCartProducts(currentUser).Result.CartProducts;
            Totalprice = MyCartProducts.Sum(product => product.Count * (product.Product?.Price ?? 0));

            const string validDiscountCode = "uWu";
            decimal Discount = 0m;
            // M til at convertere fra double til decimal
            if (DiscountCode == validDiscountCode)
            {
                Discount = 0.10m;
                DiscountApplied = true;
            }

            DiscountAmount = Math.Round(Totalprice * Discount, 2);
            FinalPrice = Math.Round(Totalprice - DiscountAmount, 2);
            // Runder op og sørger for at vi har 2 decimaler ekstra.

            return Page();
        }
    }
}

