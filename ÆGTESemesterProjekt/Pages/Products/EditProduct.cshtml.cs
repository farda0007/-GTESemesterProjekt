using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Products
{
    public class EditProductModel : PageModel
    {
        private IProductService _productService;
        [BindProperty]
        public Models.Product Product { get; set; }

        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProduct(id);
            if (Product == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu

            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.UpdateProduct(Product);
            return RedirectToPage("GetAllProducts");
        }
    }
}
