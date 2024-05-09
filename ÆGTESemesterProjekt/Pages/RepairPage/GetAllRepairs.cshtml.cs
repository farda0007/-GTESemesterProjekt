using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.RepairPage
{
    public class GetAllRepairsModel : PageModel
    {
        private IRepairService _repairService;
        public GetAllRepairsModel(IRepairService repairService) //Dependency Injection
        {
            this._repairService = repairService;
        }
        public List<Models.Repair>? Repairs { get; private set; }
        public void OnGet()
        {
            Repairs = _repairService.GetRepairs();
        }
    }
}
