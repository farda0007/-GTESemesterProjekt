using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Wishlist
{
    public class GetAllWishlistProductModel : PageModel
    {
        public UserService UserService { get; set; }

        public IEnumerable<Models.Wishlist> MyWishlist { get; set; }

        public GetAllWishlistProductModel(UserService userService)
        {
            UserService = userService;
        }

        public IActionResult OnGet()
        {
            //Udkommenteret for test af Discount
            //Models.User CurrentUser = _UserService.GetUserByUserName(HttpContext.User.Identity.Name);
            //var WishlistProduct = CurrentUser.Wishlist;
            //var WishlistProduct = _UserService.GetUserWishlist(CurrentUser).Result.Wishlist;

            return Page();
        }
    }
}
