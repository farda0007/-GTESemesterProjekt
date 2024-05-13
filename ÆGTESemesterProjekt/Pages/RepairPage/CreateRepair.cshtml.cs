using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ÆGTESemesterProjekt.Pages.RepairPage
{
    [Authorize(Roles = "employee")]
    public class CreateRepairModel : PageModel
    {



        private IWebHostEnvironment _webHostEnvironment;
        [BindProperty]
        public IFormFile? Photo { get; set; }

        private IRepairService _repairService;
        //[BindProperty]
        public List<Models.Product>? Products { get; private set; }
        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public Repair Repair { get; set; }
        private IProductService _productService;
        public CreateRepairModel(IRepairService repairService, IWebHostEnvironment webHost, IProductService productService)
        {
            _productService = productService;
            _repairService = repairService;
            _webHostEnvironment = webHost;

        }
        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    _productService.AddProduct(Product);
        //    return RedirectToPage("GetAllProducts");
        //}
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Photo != null)
            {
                if (Repair.Image != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "/images", Repair.Image);
                    System.IO.File.Delete(filePath);
                }
                Repair.Image = ProcessUploadedFile();
            }
            await _repairService.AddRepairAsync(Repair);
            return RedirectToPage("/RepairPage/GetAllRepairs");
        }
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                { Photo.CopyTo(fileStream); }
            }
            return uniqueFileName;
        }
	}
}

