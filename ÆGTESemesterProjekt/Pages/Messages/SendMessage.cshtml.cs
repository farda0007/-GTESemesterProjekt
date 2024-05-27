using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static ÆGTESemesterProjekt.Models.Message;
using ÆGTESemesterProjekt.EFDbContext;
using Microsoft.AspNetCore.Hosting;


namespace ÆGTESemesterProjekt.Pages.Messages
{
    
    public class SendMessageModel : PageModel
    {

        private readonly IMessageService _messageService;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ProductDbContext _context;

        public SendMessageModel(ProductDbContext context, IMessageService messageService, IWebHostEnvironment webHost)
        {
            _context = context;
            _messageService = messageService;
            _webHostEnvironment = webHost;
        }

        
        [BindProperty]
        public Message Message { get; set; }

        [BindProperty]
        public int SenderId { get; set; }

        [BindProperty]
        public int ReceiverId { get; set; }

        [BindProperty]
        public string MessageContent { get; set; }

        
        
        public IActionResult OnGet()
        {
            return Page();
        }

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _messageService.AddMessage(Message);
        //    return RedirectToPage("GetAllMessages");
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            var message = new Message
            {
                SenderId = SenderId,
                ReceiverId = ReceiverId,
                MessageContent = MessageContent,
                MessageDate = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Messages/GetAllMessages");
        }



    }
}
