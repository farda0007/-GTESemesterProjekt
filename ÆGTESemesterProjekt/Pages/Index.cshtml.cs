using ÆGTESemesterProjekt.Pages.Login;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			//if (LogInPageModel.LoggedInUser == null)
			//{

			//	HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			//}
		}
    }
}