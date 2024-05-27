using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ÆGTESemesterProjekt.Pages.Messages
{
    public class AnswerMessageModel : PageModel
    {
        private IMessageService _messageService;

        public AnswerMessageModel(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [BindProperty]
        public Models.Message Message { get; set; }

        
        public IActionResult OnGet(int id)
        {
            Message = _messageService.GetMessage(id);
            if (Message == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _messageService.UpdateMessage(Message);
            return RedirectToPage("GetAllMessages");
        }


    }





}