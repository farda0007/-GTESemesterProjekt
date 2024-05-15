using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ÆGTESemesterProjekt.Models.Product;

namespace ÆGTESemesterProjekt.Pages.ProductCatalog
{
    public class SpeakerModel : PageModel
    {
        private readonly IProductService _productService;

        public SpeakerModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> SpeakerProducts { get; private set; }

        public IActionResult OnGet(string productType)
        {
            // Filter products based on the specified product type
            SpeakerProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Speaker).ToList();

            return Page();
        }
    }
}
