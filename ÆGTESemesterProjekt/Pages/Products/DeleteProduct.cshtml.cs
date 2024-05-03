using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.Products
{
    public class DeleteProductModel : PageModel
    {
        private IProductService _productService;
        [BindProperty]
        public Models.Product Product { get; set; }
        public DeleteProductModel(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProduct(id);
            if (Product == null)
            {
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Models.Product deletedProduct = _productService.DeleteProduct(Product.Id);
            if (deletedProduct == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu
            return RedirectToPage("GetAllProducts");
        }

    }
}
