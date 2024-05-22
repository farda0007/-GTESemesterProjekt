using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.RepairPage
{
    [Authorize(Roles = "employee")]
    public class EditRepairModel : PageModel
    {
        private IRepairService _repairService;
        [BindProperty]
        public Models.Repair Repair { get; set; }
        public EditRepairModel(IRepairService repairService)
        {
            _repairService = repairService;
        }

        public IActionResult OnGet(int id)
        {
            Repair = _repairService.GetRepair(id);
            if (Repair == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _repairService.UpdateRepair(Repair);
            return RedirectToPage("/RepairPage/GetAllRepairs");
        }
    }
}
