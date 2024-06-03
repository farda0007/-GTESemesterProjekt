using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Products
{
    public class DetailProductModel : PageModel
    {
        public UserService _userService;
        public ShoppingCartService _cartService;

        [BindProperty]
        public Models.Product product { get; set; }
        public Models.User user { get; set; }
        public Product Product { get; set; }
        public Models.ShoppingCart ShoppingCart { get; set; } = new Models.ShoppingCart();
        [BindProperty]
        public int Count { get; set; }

        private IProductService _productService;

        public DetailProductModel(IProductService productService, UserService userService, ShoppingCartService cartService)
        {
            _productService = productService;
            _userService = userService;
            _cartService = cartService;
        }


        public IActionResult OnGet(int id)
        {
            product = _productService.GetProduct(id);
            if (product == null)

                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();

        }
        [Authorize]
        public IActionResult OnPost(int id)
        {
            if (User.Identity.IsAuthenticated)
            {

                Product = _productService.GetProduct(id);
                user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
                ShoppingCart.userId = user.UserId;
                ShoppingCart.ProductId = Product.Id;
                ShoppingCart.Count = Count;
                _cartService.AddCart(ShoppingCart);
                return RedirectToPage("/ShoppingCart/MyCart");

            }
            else { return RedirectToPage("/Login/LogInPage"); }
        }

    }
}
