using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ÆGTESemesterProjekt.Models.Product;

namespace ÆGTESemesterProjekt.Pages.ProductCatalog
{
    public class RecordPlayerModel : PageModel
    {
        private readonly IProductService _productService;

        public RecordPlayerModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> RecordPlayerProducts { get; private set; }

        public IActionResult OnGet(string productType)
        {
            // Filter products based on the specified product type
            RecordPlayerProducts = _productService.GetProducts().Where(p => p.Type == Producttype.RecordPlayer).ToList();

            return Page();
        }
    }
}
