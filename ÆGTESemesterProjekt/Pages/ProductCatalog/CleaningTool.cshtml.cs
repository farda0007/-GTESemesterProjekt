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
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }
        [BindProperty]

        public int MaxPrice { get; set; }

        public CleaningToolModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> CleaningToolProducts { get; private set; }


        public IActionResult OnGet()
        {
            //Først bliver metoden i _productService kaldt, og den henter listen af produkter. Derefter bruges LINQ. "Where" er en LINQ metode, der filtrerer produkter.
            //"Where" tager et lambda expression som paramatre.
            CleaningToolProducts = _productService.GetProducts().Where(p => p.Type == Producttype.RengøringsUdstyr).ToList();

            return Page();
        }
        public IActionResult OnPostNameSearch()
        {
            CleaningToolProducts = _productService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostPriceFilter()
        {
            CleaningToolProducts = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
