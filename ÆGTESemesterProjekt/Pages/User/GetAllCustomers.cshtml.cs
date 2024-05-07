using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.User
{
    [Authorize(Roles = "employee")]
    public class GetAllCustomersModel : PageModel
    {
        private UserService _userService;
        public GetAllCustomersModel (UserService userService)
        {
            this._userService = userService;
        }
        public List<Models.User> users { get; private set; } = new List<Models.User>();
        public void OnGet()
        {
            users = _userService.GetUsers();
        }
    }
}
