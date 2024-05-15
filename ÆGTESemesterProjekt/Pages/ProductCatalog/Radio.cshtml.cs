using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ÆGTESemesterProjekt.Models.Product;

namespace ÆGTESemesterProjekt.Pages.ProductCatalog
{
    public class RadioModel : PageModel
    {
        private readonly IProductService _productService;
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }
        [BindProperty]

        public int MaxPrice { get; set; }

        public RadioModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> RadioProducts { get; private set; }

        public IActionResult OnGet(string productType)
        {
            // Filter products based on the specified product type
            RadioProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Radio).ToList();

            return Page();
        }
        public IActionResult OnPostNameSearch()
        {
            RadioProducts = _productService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostPriceFilter()
        {
            RadioProducts = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
