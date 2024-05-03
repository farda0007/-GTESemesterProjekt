using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ÆGTESemesterProjekt.Services;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Pages.Login
{
    public class LogInPageModel : PageModel
    {

        //public static User LoggedInUser { get; set; } = null;

        private UserService _userService;

        public LogInPageModel(UserService userService)
        {
            _userService = userService;
        }
        [BindProperty]

        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPost()
        {

            List<Employee> users = _userService.Users;
            foreach (Models.User user in users)
            {
                if (UserName == user.UserName)
                {
                    var passwordHasher = new PasswordHasher<string>();

                    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                    {
                        //LoggedInUser = user;

                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) };

                        if (UserName == "Employee") claims.Add(new Claim(ClaimTypes.Role, "Employee"));

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Product/GetAllProducts");
                    }
                }
            }
            Message = "Invalid attempt";
            return Page();
        }
    }
}
