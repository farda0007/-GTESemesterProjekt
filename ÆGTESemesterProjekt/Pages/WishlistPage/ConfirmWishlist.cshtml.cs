using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ÆGTESemesterProjekt.Pages.Wishlist
{
    public class ConfirmWishlistModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly UserService _userService;
        private readonly WishlistService _wishlistService;

        public Models.User User { get; set; }
        public Product Product { get; set; }
        public Models.Wishlist Wishlist { get; set; } = new Models.Wishlist();

        public ConfirmWishlistModel(IProductService productService, UserService userService, WishlistService wishlistService)
        {
            _productService = productService;
            _userService = userService;
            _wishlistService = wishlistService;
        }

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProduct(id);
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);


            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product = _productService.GetProduct(id);
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            Wishlist.userId = User.UserId;
            Wishlist.ProductId = Product.Id;
            _wishlistService.AddWishlist(Wishlist);
            return RedirectToPage("/WishlistPage/Wishlist");
        }
    }
}