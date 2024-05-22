using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;

namespace ÆGTESemesterProjekt.Pages.Messages
{
    public class SendMessageModel : PageModel
    {
        private readonly ProductDbContext _context;

        public SendMessageModel(ProductDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int CustomerId { get; set; }
        [BindProperty]
        public int EmployeeId { get; set; }
        [BindProperty]
        public string MessageContent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var message = new Message
            {
                SenderId = CustomerId,
                ReceiverId = EmployeeId,
                MessageContent = MessageContent,
                MessageDate = DateTime.Now
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Messages/SendMessageModel");
        }

    }
}
