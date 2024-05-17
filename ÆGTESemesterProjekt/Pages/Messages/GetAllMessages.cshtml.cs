using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ÆGTESemesterProjekt.Services;
using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Pages.Messages
{
    public class GetAllMessagesModel : PageModel
    {
        private readonly DbService _dbService;

        public GetAllMessagesModel(DbService dbService)
        {
            _dbService = dbService;
        }

        public List<Message> messages { get; set; }

        public async Task OnGetAsync()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            messages = await _dbService.GetMessageAsync(userId);
        }
    }
}
