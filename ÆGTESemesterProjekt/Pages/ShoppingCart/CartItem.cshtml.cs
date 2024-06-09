using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.ShoppingCart
{
    public class CartItemModel : PageModel
    {
        public IProductService _productService;
        public UserService _userService;
        public ShoppingCartService _cartService;

        public Models.User User { get; set; }
        public Product Product { get; set; }
        public Models.ShoppingCart ShoppingCart { get; set; } = new Models.ShoppingCart();
        [BindProperty]
        public int Count { get; set; }

        public CartItemModel(IProductService productService, UserService userService, ShoppingCartService cartService)
        {
            _productService = productService;
            _userService = userService;
            _cartService = cartService;
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
            //Henter produktet med det givet Id,
            Product = _productService.GetProduct(id);
            //Henter brugernavnet fra databasen vha. _userService. Det giver os en user der repræsenterer den aktuelle bruger.
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            //Binder den gældende user til shoppingCart.
            ShoppingCart.userId = User.UserId;
            ShoppingCart.ProductId = Product.Id;
            ShoppingCart.Count = Count;
            _cartService.AddCart(ShoppingCart);
            return RedirectToPage("/Products/GetAllProducts");

        }
    }
}
