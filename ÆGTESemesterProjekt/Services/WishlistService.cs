using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class WishlistService : IWishlistService
    {
        private List<Wishlist> _wishlists;
        private JsonFileService<Wishlist> _wishlistJsonFileService;
        private DbGenericService<Wishlist> _dbService;


        public WishlistService(JsonFileService<Wishlist> wishlistJsonFileService, DbGenericService<Wishlist> dbService)
        {
            //_wishlists = wishlists;
            _wishlistJsonFileService = wishlistJsonFileService;
            _dbService = dbService;
            _wishlists = _dbService.GetObjectsAsync().Result.ToList();

            //_wishlistJsonFileService.SaveJsonObjects(_wishlists);
            _dbService.SaveObjects(_wishlists);
        }

        public async Task AddWishlistAsync(Wishlist wishlist)
        {
            _wishlists.Add(wishlist);
            await _dbService.AddObjectAsync(wishlist);
        }
        public Wishlist DeleteWishlist(int? productId)
        {
            foreach (Wishlist product in _wishlists)
            {
                if (product.WishlistId == productId)
                {
                    _wishlists.Remove(product);
                    _dbService.DeleteObjectAsync(product);
                    return product;
                }
            }
            return null;
        }

        public Wishlist GetWishlist(int Id)
        {
            foreach (Wishlist product in _wishlists)
            {
                if (Id == product.WishlistId)
                {
                    return product;
                }
            }
            return null;
        }
        public List<Wishlist> GetWishlists()
        {
            return _wishlists;
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


