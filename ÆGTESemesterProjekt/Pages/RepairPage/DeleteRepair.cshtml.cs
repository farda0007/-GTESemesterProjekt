using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Pages.RepairPage;
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
                return RedirectToPage("/NotFound"); //NotFound is not defined yet
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ÆGTESemesterProjekt.Models.Repair deletedRepair = await _repairService.DeleteRepairAsync(Repair.CaseId);
            if (deletedRepair == null)
                return RedirectToPage("/NotFound"); //NotFound is not defined yet
            return RedirectToPage("/RepairPage/GetAllRepairs");
        }

    }
}


