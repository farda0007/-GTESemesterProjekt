using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{

    public interface IWishlistService
    {
        Task<Wishlist> OnGetWishlistItemsById(int wishlistId);
    }
   


}
