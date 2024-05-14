using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.RepairPage
{
    [Authorize(Roles = "employee")]
    public class DeleteRepairModel : PageModel
    {
        private IRepairService _repairService;
        [BindProperty]
        public Models.Repair Repair { get; set; }
        public DeleteRepairModel(IRepairService repairService)
        {
            _repairService = repairService;
        }


        public IActionResult OnGet(int id)
        {
            Repair = _repairService.GetRepair(id);
            if (Repair == null)
            {
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Models.Repair deletedRepair = _repairService.DeleteRepair(Repair.CaseId);
            if (deletedRepair == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu
            return RedirectToPage("/RepairPage/GetAllRepairs");
        }

    }
}

