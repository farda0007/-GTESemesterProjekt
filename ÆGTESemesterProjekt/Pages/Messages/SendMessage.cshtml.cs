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
        //private readonly ProductDbContext _context;

        //public SendMessageModel(ProductDbContext context)
        //{
        //    _context = context;
        //}

        //[BindProperty]
        //public int SenderId { get; set; }
        //[BindProperty]
        //public int ReceiverId { get; set; }
        //[BindProperty]
        //public string MessageTitle { get; set; }
        //[BindProperty]
        //public string MessageContent { get; set; }
        //[BindProperty]
        //public string MessageAuthor { get; set; }

        private readonly Message _message;

        [BindProperty]
        public Message Message { get; set; }

        public SendMessageModel(Message message)
        {
            _message = message;
        }

        //public void OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _message.SendMessage(Message);
        //    }
        //}


    }
}
