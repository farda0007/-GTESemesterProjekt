using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public interface IWishlistService
    {
        Task AddWishlistAsync(Wishlist wishlist);
        Task<Wishlist> DeleteWishlistAsync(int? wishlistId);
        Wishlist GetWishlist(int Id);
    }
}
