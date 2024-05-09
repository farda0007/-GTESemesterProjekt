using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Wishlist
{
    public class WishlistProductModel : PageModel
    {
        //public IProductService _productService;
        //public UserService _userService;
        //public WishlistService _wishlistService;

        //public Models.User user { get; set; }
        //public Product product { get; set; }
        //public Models.Wishlist wishlist { get; set; } = new Models.Wishlist();

        //public WishlistProductModel(IProductService productService, UserService userService, WishlistService wishlistService)
        //{
        //    _productService = productService;
        //    _userService = userService;
        //    _wishlistService = wishlistService;
        //}

        //public void OnGet(int id)
        //{
        //    product = _productService.GetProduct(id);
        //    user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
        //}

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    product = _productService.GetProduct(id);
        //    user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
        //    wishlist.userId = user.UserId;
        //    wishlist.ProductId = product.Id;
        //    _wishlistService.AddToWishlist(wishlist);
        //    return RedirectToPage("/Products/GetAllProducts");
        //}
    }
}
