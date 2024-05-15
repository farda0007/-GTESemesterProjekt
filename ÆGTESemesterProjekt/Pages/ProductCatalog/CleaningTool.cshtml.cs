using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ÆGTESemesterProjekt.Models.Product;

namespace ÆGTESemesterProjekt.Pages.ProductCatalog
{
    public class CleaningToolModel : PageModel
    {
        private readonly IProductService _productService;

        public CleaningToolModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> CleaningToolProducts { get; private set; }

        public IActionResult OnGet(string productType)
        {
            // Filter products based on the specified product type
            CleaningToolProducts = _productService.GetProducts().Where(p => p.Type == Producttype.CleaningTool).ToList();

            return Page();
        }
    }
}
