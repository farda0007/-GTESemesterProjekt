using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static ÆGTESemesterProjekt.Models.Product;

namespace ÆGTESemesterProjekt.Pages.Products
{
    [Authorize(Roles = "employee")]
    public class CreateProductModel : PageModel
    {

		[BindProperty]
		public string TypeSelect { get; set; }
		private IWebHostEnvironment _webHostEnvironment;
		[BindProperty]
		public IFormFile? Photo { get; set; }

		private IProductService _productService;
        [BindProperty]

        public Product Product { get; set; }

		public CreateProductModel(IProductService productService, IWebHostEnvironment webHost)
		{
			_productService = productService;
			_webHostEnvironment = webHost;
		}
        public IActionResult OnGet()
        {
            return Page();
        }
		//public IActionResult OnPost()
		//{
		//    if (!ModelState.IsValid)
		//    {
		//        return Page();
		//    }
		//    _productService.AddProduct(Product);
		//    return RedirectToPage("GetAllProducts");
		//}
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			if (Photo != null)
			{
				if (Product.ProductImage != null)
				{
					string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "/images", Product.ProductImage);
					System.IO.File.Delete(filePath);
				}
				Product.ProductImage = ProcessUploadedFile();
			}
			Product product = new Product
			{
				Id = this.Product.Id,
				ProductName = this.Product.ProductName,
				Price = this.Product.Price,
				Description = this.Product.Description,
				ProductImage = this.Product.ProductImage,
				
				Type = (Producttype)Enum.Parse(typeof(Producttype), TypeSelect)
			};
			await _productService.AddProductAsync(Product);
			return RedirectToPage($"/Products/{TypeSelect}");
		}
		private string ProcessUploadedFile()
		{
			string uniqueFileName = null;
			if (Photo != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;

				string filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{ Photo.CopyTo(fileStream); }
			}
			return uniqueFileName;
		}
	}
}
