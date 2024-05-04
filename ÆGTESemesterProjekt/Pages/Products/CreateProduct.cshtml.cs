using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        private IProductService _productService;
        [BindProperty]
        public Product Product { get; set; }
        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.AddProduct(Product);
            return RedirectToPage("GetAllProducts");
        }
    }
}
