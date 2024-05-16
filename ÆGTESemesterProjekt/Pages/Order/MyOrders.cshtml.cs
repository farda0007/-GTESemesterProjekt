using ÆGTESemesterProjekt.DAO;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Order
{
    public class MyOrdersModel : PageModel
    {
        [BindProperty]
        public string DiscountCode { get; set; }
        public decimal Totalprice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public bool DiscountApplied { get; set; }

        public UserService UserService { get; set; }

        public IEnumerable<Models.Order> MyOrders { get; set; }

        public MyOrdersModel(UserService userService)
        {
            UserService = userService;
        }

        public IActionResult OnGet()
        {
            Models.User CurrentUser = UserService.GetUserByUserName(HttpContext.User.Identity.Name);
            MyOrders = UserService.GetUserOrders(CurrentUser).Result.Orders;

            return Page();
        }

        public void OnPost()
        {
            const string validDiscountCode = "uWu";
            decimal Discount = 0.10m;

            if (DiscountCode == validDiscountCode)
            {
                Discount = 0.10m;
                DiscountApplied = true;
            }

            DiscountAmount = Totalprice * Discount;
            FinalPrice = Totalprice - DiscountAmount;

        }
    }
}
