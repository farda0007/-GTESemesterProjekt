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
using Microsoft.Extensions.Logging;

namespace ÆGTESemesterProjekt.Pages.Messages
{
    public class GetAllMessagesModel : PageModel
    {
        private readonly ProductDbContext _context;
         
        public GetAllMessagesModel(ProductDbContext context)
        {
            _context = context;
        }

        public IList<Message> Messages { get; set; }

        public async Task OnGetAsync(int userId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = await _context.User.FirstOrDefaultAsync(u => u.UserName == "Employee");

            //if (employee != null)
            //{
            //    Messages = await _context.Messages
            //        .Include(m => m.Sender)
            //        .Include(m => m.Receiver)
            //        .Where(m => m.SenderId == userId && m.ReceiverId == userId)
            //        .ToListAsync();

            //    _logger.LogInformation("Messages Count: {Count}", Messages.Count);
            //}
            //else
            //{
            //    Messages = new List<Message>();
            //}

        }
    }
}
