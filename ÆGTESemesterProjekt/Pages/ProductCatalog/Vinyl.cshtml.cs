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

		public VinylModel(IProductService productService)
		{
			_productService = productService;
		}

		public List<Product> VinylProducts { get; private set; }

		public IActionResult OnGet(string productType)
		{
			// Filter products based on the specified product type
			VinylProducts = _productService.GetProducts().Where(p => p.Type == Producttype.Vinyl).ToList();

			return Page();
		}
	}
}
