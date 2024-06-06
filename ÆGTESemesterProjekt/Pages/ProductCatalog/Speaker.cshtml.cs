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
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }
        [BindProperty]

        public int MaxPrice { get; set; }

        public SpeakerModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> SpeakerProducts { get; private set; }

        public IActionResult OnGet()
        {
            //Først bliver metoden i _productService kaldt, og den henter listen af produkter. Derefter bruges LINQ. "Where" er en LINQ metode, der filtrerer produkter.
            //"Where" tager et lambda expression som paramatre.
            SpeakerProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Højtaler).ToList();

            return Page();
        }
        public IActionResult OnPostNameSearch()
        {
            SpeakerProducts = _productService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostPriceFilter()
        {
            SpeakerProducts = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
