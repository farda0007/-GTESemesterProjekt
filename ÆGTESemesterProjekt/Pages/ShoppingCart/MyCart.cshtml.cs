using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.ShoppingCart
{
    public class MyCartModel : PageModel
    {
        public UserService UserService;
        public IEnumerable<Models.ShoppingCart> MyCartProducts { get; set; }
        public IActionResult OnGet()
        {
            Models.User CurrentUser = UserService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyCartProducts = UserService.GetCartProducts(CurrentUser).Result.CartProducts;

            return Page();
        }
    }
}
