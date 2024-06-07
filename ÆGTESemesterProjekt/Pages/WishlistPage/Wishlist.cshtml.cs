using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace ÆGTESemesterProjekt.Pages.WishlistPage
{
    public class WishlistModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly UserService _userService;
        private readonly WishlistService _wishlistService;

        public List<Models.Product> Products { get; private set; } = new List<Models.Product>();
        public IEnumerable<Models.Wishlist> MyWishlist { get; private set; }

        public WishlistModel(IProductService productService, WishlistService wishlistService, UserService userService)
        {
            _productService = productService;
            _wishlistService = wishlistService;
            _userService = userService;
        }

        public IActionResult OnGet()
        {

            var currentUser = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyWishlist = _userService.GetWishlistProducts(currentUser).Result.WishlistProducts;
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteWishlist(int wishlistId)
        {
            await _wishlistService.DeleteWishlistAsync(wishlistId);

            var currentUser = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyWishlist= _userService.GetCartProducts(currentUser).Result.WishlistProducts;

            return RedirectToPage();
        }
    }
}
