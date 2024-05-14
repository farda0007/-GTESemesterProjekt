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
            Models.User CurrentUser = UserService.GetUserByUserName(HttpContext.User.Identity.Name);

            return Page();
        }
    }
}
