using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.EFDbContext;


namespace ÆGTESemesterProjekt.Pages.Messages
{
    public class GetAllMessagesModel : PageModel
    {
        private readonly ProductDbContext _context;
        public IList<Message> Messages { get; set; }
        private IMessageService _messageService;

        public GetAllMessagesModel(ProductDbContext context, IMessageService messageService) //Dependency Injection
        {
            _context = context;
            this._messageService = messageService;
        }


        public void OnGet()
        {
            Messages = _messageService.GetMessages() ?? new List<Message>();
        }



    }
}
