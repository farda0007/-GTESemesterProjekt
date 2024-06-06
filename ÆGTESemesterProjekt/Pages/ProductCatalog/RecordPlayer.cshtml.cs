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
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }
        [BindProperty]

        public int MaxPrice { get; set; }

        public RecordPlayerModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> RecordPlayerProducts { get; private set; }

        public IActionResult OnGet()
        {
            //Først bliver metoden i _productService kaldt, og den henter listen af produkter. Derefter bruges LINQ. "Where" er en LINQ metode, der filtrerer produkter.
            //"Where" tager et lambda expression som paramatre.
            RecordPlayerProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Pladespiller).ToList();

            return Page();
        }
        public IActionResult OnPostNameSearch()
        {
            RecordPlayerProducts = _productService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostPriceFilter()
        {
            RecordPlayerProducts = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
