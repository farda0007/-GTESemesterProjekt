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
        private readonly ShoppingCartService _shoppingCartService;
        public IEnumerable<Models.ShoppingCart> MyCartProducts { get; set; }

        public MyCartModel(UserService userService, ShoppingCartService shoppingCartService)
        {
            _userService = userService;
            _shoppingCartService = shoppingCartService;
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

            const string validDiscountCode = "uWu";
            decimal discount = 0m;

            if (DiscountCode == validDiscountCode)
            {
                discount = 0.10m;
                DiscountApplied = true;
            }

            decimal totalPrice = MyCartProducts.Sum(product => product.Count * (product.Product?.Price ?? 0));
            DiscountAmount = Math.Round(totalPrice * discount, 2);
            FinalPrice = Math.Round(totalPrice - DiscountAmount, 2);

            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int cartId)
        {   
            await _shoppingCartService.DeleteCart(cartId);


            return RedirectToPage();
        }
    }
}

