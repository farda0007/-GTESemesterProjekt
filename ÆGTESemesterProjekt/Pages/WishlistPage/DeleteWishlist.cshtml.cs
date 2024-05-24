using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ÆGTESemesterProjekt.Pages.WishlistPage
{
    public class DeleteWishlistModel : PageModel
    {

        private IWishlistService _iwishlistService;
        [BindProperty]
        public Models.Wishlist Wishlist { get; set; }
        public DeleteWishlistModel(IWishlistService iwishlistService)
        {
            _iwishlistService = iwishlistService;

        }


        public IActionResult OnGet(int Id)
        {
            Wishlist = _iwishlistService.GetWishlist(Id);
            if (Wishlist == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Models.Wishlist deletedProduct = _iwishlistService.DeleteWishlist(Wishlist.WishlistId);
            if (deletedProduct == null)
                return RedirectToPage("/NotFound"); //NotFound er ikke defineret endnu
            return RedirectToPage("Wishlist");
        }

    }
}


