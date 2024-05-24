using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public interface IWishlistService
    {
        Task AddWishlistAsync(Wishlist wishlist);
        Wishlist DeleteWishlist(int? wishlistId);
        Wishlist GetWishlist(int Id);
    }
}
