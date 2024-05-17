using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class WishlistService
    {
        private readonly List<Wishlist> _wishlists = new List<Wishlist>();

        public void AddWishlist(Wishlist wishlist)
        {
            _wishlists.Add(wishlist);
        }

        public List<Wishlist> GetWishlistByUserId(int userId)
        {
            return _wishlists.Where(w => w.userId == userId).ToList();
        }
    }
}


