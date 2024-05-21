using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ÆGTESemesterProjekt.Services;
using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Pages.Messages
{
    public class GetAllMessagesModel : PageModel
    {
        private readonly ProductDbContext _context;

        public GetAllMessagesModel(ProductDbContext context)
        {
            _context = context;
        }

        public List<Message> Messages { get; set; }

        [BindProperty]
        public int UserId { get; set; }

        public async Task OnGetAsync(int userId)
        {
            UserId = userId;
            Messages = await _context.Messages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToListAsync();
        }
    }
}
