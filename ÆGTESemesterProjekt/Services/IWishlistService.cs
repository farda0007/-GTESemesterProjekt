using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public interface IWishlistService
    {
        Wishlist DeleteWishlist(int? wishlistId);
        Wishlist GetWishlist(int Id);
    }
}
