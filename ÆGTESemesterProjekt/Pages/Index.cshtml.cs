using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages
{

    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public List<Product> Products { get; private set; }

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}
//	public class IndexModel : PageModel
//	{
//		private readonly ILogger<IndexModel> _logger;
//        public List<Models.Product> product1 { get; private set; } = new List<Models.Product>();

//        public IndexModel(ILogger<IndexModel> logger)
//		{
//			_logger = logger;
//		}

//        //public List<Models.Product> Products;

//        public void OnGet()
//		{
//			//if (LogInPageModel.LoggedInUser == null)
//			//{

//			//	HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

//			//}
//		}
//    }
//}