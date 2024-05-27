using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly List<Wishlist> _wishlists = new List<Wishlist>();
        private JsonFileService<Wishlist> _wishlistJsonFileService;
        private DbGenericService<Wishlist> _dbService;


        public WishlistService(JsonFileService<Wishlist> wishlistJsonFileService, DbGenericService<Wishlist> dbService)
        {
            //_wishlists = wishlists;
            _wishlistJsonFileService = wishlistJsonFileService;
            _dbService = dbService;
            //_wishlists = _dbService.GetObjectsAsync().Result.ToList();

            _wishlistJsonFileService.SaveJsonObjects(_wishlists);
           // _dbService.SaveObjects(_wishlists);
        }

        public async Task AddWishlist(Wishlist wishlist)
        {
            _wishlists.Add(wishlist);
            await _dbService.AddObjectAsync(wishlist);
            _wishlistJsonFileService.SaveJsonObjects(_wishlists);
        }
        public Wishlist DeleteWishlist(int? WishlistId)
        {
            foreach (Wishlist wishlist in _wishlists)
            {
                if (wishlist.WishlistId == WishlistId)
                {
                    _wishlists.Remove(wishlist);
                    _wishlistJsonFileService.SaveJsonObjects(_wishlists);
                    _dbService.DeleteObjectAsync(wishlist);
                    return wishlist;
                }
            }
            return null;
        }
        public Wishlist GetWishlist(int Id)
        {
            foreach (Wishlist wishlist in _wishlists)
            {
                if (Id == wishlist.WishlistId)
                {
                    return wishlist;
                }
            }
            return null;
        }
        public List<Wishlist> GetWishlistByUserId(int userId)
        {
            return _wishlists.Where(w => w.userId == userId).ToList();
        }

        public Task<Wishlist> OnGetWishlistItemsById(int wishlistId)
        {
            throw new NotImplementedException();
        }
    }
}


