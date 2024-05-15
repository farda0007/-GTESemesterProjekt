using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ÆGTESemesterProjekt.Models.Product;

namespace ÆGTESemesterProjekt.Pages.ProductCatalog
{
    public class HeadsetModel : PageModel
    {
        private readonly IProductService _productService;

        public HeadsetModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> HeadsetProducts { get; private set; }

        public IActionResult OnGet(string productType)
        {
            // Filter products based on the specified product type
            HeadsetProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Headset).ToList();

            return Page();
        }
    }
}
