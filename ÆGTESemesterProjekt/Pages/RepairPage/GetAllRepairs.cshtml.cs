using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.RepairPage
{
    public class GetAllRepairsModel : PageModel
    {
        public List<Models.Repair>? Repairs { get; private set; }
        public void OnGet()
        {
        }
    }
}
