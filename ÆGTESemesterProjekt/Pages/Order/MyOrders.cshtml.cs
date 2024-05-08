using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Order
{
    public class MyOrdersModel : PageModel
    {
        public UserService _UserService { get; set; }

        public IEnumerable<Models.Order> MyOrders { get; set; }

        public MyOrdersModel(UserService userService)
        {
            _UserService = userService;
        }

        public IActionResult OnGet()
        {
            Models.User CurrentUser = _UserService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyOrders = _UserService.GetUserOrdersAsync(CurrentUser).Result.Orders;

            return Page();
        }
    }
}
