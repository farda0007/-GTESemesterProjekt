using ÆGTESemesterProjekt.Models;
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


        public IActionResult OnGet(int id)
        {
            Wishlist = _iwishlistService.GetWishlist(id);
            if (Wishlist == null)
            {
                return RedirectToPage("/NotFound"); //NotFound is not defined yet
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ÆGTESemesterProjekt.Models.Wishlist deletedWishlist = await _iwishlistService.DeleteWishlistAsync(Wishlist.WishlistId);
            if (deletedWishlist == null)
                return RedirectToPage("/NotFound"); //NotFound is not defined yet
            return RedirectToPage("/Wishlist");
        }

    }
}


