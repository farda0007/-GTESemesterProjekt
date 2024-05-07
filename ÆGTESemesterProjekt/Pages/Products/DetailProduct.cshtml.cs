using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Products
{
    public class DetailProductModel : PageModel
    {
        [BindProperty]
        public Models.Product product { get; set; }

        private IProductService _productService;

        public DetailProductModel(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult OnGet(int id)
        {
            product = _productService.GetProduct(id);
            if (product == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
    }
}
