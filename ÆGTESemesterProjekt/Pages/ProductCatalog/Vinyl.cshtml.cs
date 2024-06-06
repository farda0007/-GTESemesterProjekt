using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ÆGTESemesterProjekt.Models.Product;

namespace ÆGTESemesterProjekt.Pages.ProductCatalog
{
	public class VinylModel : PageModel
	{
		private readonly IProductService _productService;
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }
        [BindProperty]
        public int MaxPrice { get; set; }
        public VinylModel(IProductService productService)
		{
			_productService = productService;
		}

		public List<Product> VinylProducts { get; private set; }

		public IActionResult OnGet()
		{
            //Find listen af produkter. "Where" er en LINQ metode der bliver brugt til at filtrere produkter. "Where" bruger lambda expression som parameter
            VinylProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Vinyl).ToList();

			return Page();
		}
        public IActionResult OnPostNameSearch()
        {
            VinylProducts = _productService.NameSearch(SearchString).ToList();
            return Page();
        }
        public IActionResult OnPostPriceFilter()
        {
            VinylProducts = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }
    }
}
