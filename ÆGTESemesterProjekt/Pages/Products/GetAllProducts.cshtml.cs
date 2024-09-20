using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Products
{
    public class GetAllProductsModel : PageModel
    {
        private IProductService _productService;
        public List<Models.Product>? Products { get; private set; }
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public int MinPrice { get; set; }
        [BindProperty]
        public int MaxPrice { get; set; }
        public GetAllProductsModel(IProductService productService) 
        {
            this._productService = productService;
        }
        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
        public IActionResult OnPostNameSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchString))
            {

                return RedirectToPage("GetAllProducts");
            }

            Products = _productService.NameSearch(SearchString).ToList();
            return Page();
        }

        public IActionResult OnPostPriceFilter()
        {
            Products = _productService.PriceFilter(MaxPrice, MinPrice).ToList();
            return Page();
        }

    }
}
