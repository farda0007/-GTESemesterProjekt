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

        //public static Models.User LoggedInUser { get; set; } = null;

        private UserService _userService;

        public LogInPageModel(UserService userService)
        {
            _userService = userService;
        }
        [BindProperty]

        [Display(Name = "Dit Brugernavn")]
        public string UserName { get; set; }
        
        [BindProperty, DataType(DataType.Password)]
        [Display(Name = "Din Adgangskode")]
        [Required(ErrorMessage = "Der skal angives en kode")]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPost()
        {
            List<Models.User> users = _userService.Users;
            foreach (Models.User user in users)
            {
                if (UserName == user.UserName)
                {
                    var passwordHasher = new PasswordHasher<Models.User>();

                    //// Verify the hashed password using the PasswordHasher
                    if (passwordHasher.VerifyHashedPassword(user, user.Password, Password) == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, UserName) };

                        if (UserName == "employee")
                        {
                            claims.Add(new Claim(ClaimTypes.Role, "employee"));
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    }
                }
            }
            Message = "Invalid attempt";
            return Page();
        }
    }
}
