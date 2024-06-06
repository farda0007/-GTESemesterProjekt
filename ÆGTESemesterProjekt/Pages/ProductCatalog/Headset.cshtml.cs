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
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }
        [BindProperty]

        public int MaxPrice { get; set; }
        public HeadsetModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> HeadsetProducts { get; private set; }

        public IActionResult OnGet()
        {
            //Find listen af produkter. "Where" er en LINQ metode der bliver brugt til at filtrere produkter. "Where" bruger lambda expression som parameter
            HeadsetProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Headset).ToList();

            return Page();
        }
        public IActionResult OnPostNameSearch()
        {
            HeadsetProducts = _productService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostPriceFilter()
        {
            HeadsetProducts = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
