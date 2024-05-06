using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ÆGTESemesterProjekt.Pages.User
{
    public class CreateUserModel : PageModel
    {
        private PasswordHasher<string> passwordHasher;
        private UserService _userService;
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public CreateUserModel(UserService userService)
        {
            this.passwordHasher = new PasswordHasher<string>();
            _userService = userService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _userService.AddUserAsync(new Customer(Id, UserName, Name, passwordHasher.HashPassword(null, Password), Phone, Email));
            //_userService.AddUser(new User(UserName, Password));
            return RedirectToPage("/Index");
    }
    }
}
