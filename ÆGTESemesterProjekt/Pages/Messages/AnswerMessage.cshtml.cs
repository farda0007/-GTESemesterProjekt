using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ÆGTESemesterProjekt.Pages.Messages
{
    [Authorize(Roles = "employee")]
    public class AnswerMessageModel : PageModel
    {
        private readonly ProductDbContext _context;

        public AnswerMessageModel(ProductDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int MessageId { get; set; }
        [BindProperty]
        public string AnswerContent { get; set; }

        public Message OriginalMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int messageId)
        {
            OriginalMessage = await _context.Messages.FindAsync(messageId);
            if (OriginalMessage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = GetCurrentUserId();

            var answerMessage = new Message
            {
                SenderId = userId,
                ReceiverId = OriginalMessage.SenderId,
                MessageContent = AnswerContent,
                MessageDate = DateTime.Now,
                ParentMessageId = MessageId
            };

            _context.Messages.Add(answerMessage);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Messages/AnswerMessageModel", new { messageId = MessageId });
        }

        private int GetCurrentUserId()
        {
            // Logic to get the current user's ID from the authentication context
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
