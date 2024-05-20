using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public interface IWishlistService
    {
        //List<Wishlist> GetWishlist();
        //Task AddWishlistAsync(Wishlist wishlist);
        //void AddWishlist(Wishlist wishlist);
        //void UpdateRepair(Repair repair);
        Wishlist DeleteWishlist(int? wishlistID);
        Wishlist GetWishlist(int Id);
    }
}
