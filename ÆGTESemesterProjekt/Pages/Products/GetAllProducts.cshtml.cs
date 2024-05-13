using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace ÆGTESemesterProjekt.Pages.Products
{
    public class GetAllProductsModel : PageModel
    {
		private IProductService _productService;
		public List<Models.Product>? Products { get; private set; }
		[BindProperty] 
		public string SearchString { get; set; }
		public GetAllProductsModel(IProductService productService) //Dependency Injection
		{
			this._productService = productService;
		}
		public void OnGet()
		{
			Products = _productService.GetProducts();
		}
		public IActionResult OnPostNameSearch()
		{
			Products = _productService.NameSearch(SearchString).ToList();
			return Page();
		}

	}
}
