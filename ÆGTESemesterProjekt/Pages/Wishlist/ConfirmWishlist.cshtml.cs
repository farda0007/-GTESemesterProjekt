using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Wishlist
{
    public class ConfirmWishlistModel : PageModel
    {

        public IProductService _productService;
        public UserService _userService;
        public WishlistService _wishlistService;

        public Models.User User { get; set; }
        public Product Product { get; set; }
        public Models.Wishlist Wishlist { get; set; } = new Models.Wishlist();
  

        public ConfirmWishlistModel(IProductService productService, UserService userService, WishlistService wishlistService)
        {
            _productService = productService;
            _userService = userService;
            _wishlistService = wishlistService;
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
            Product = _productService.GetProduct(id);
            User = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            Wishlist.userId = User.UserId;
            Wishlist.ProductId = Product.Id;
            
            _wishlistService.AddWishlist(Wishlist);
            return RedirectToPage("/Wishlist/GetAllWishlistProduct");
        }
    }
}
