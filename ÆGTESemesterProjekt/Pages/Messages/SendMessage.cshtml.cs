using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;

namespace ÆGTESemesterProjekt.Pages.Messages
{
    public class SendMessageModel : PageModel
    {
        private readonly DbService _dbService;

        public SendMessageModel(DbService dbService)
        {
            _dbService = dbService;
        }

        [BindProperty]
        public int RecipientId { get; set; }

        [BindProperty]
        public string Content { get; set; }

        public SelectList Users { get; set; }

        public async Task OnGetAsync()
        {
            var users = await _dbService.GetUsers();
            Users = new SelectList(users, "UserId", "UserName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var message = new Message
            {
                Content = Content,
                TimeStamp = DateTime.Now,
                SenderId = UserId,
                RecipientId = RecipientId
            };
            await _dbService.SendMessageAsync(message);
            return RedirectToPage("./index");
        }
    }
}
