﻿using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class WishlistService : IWishlistService
    {
        private List<Wishlist> _wishlists;
        private DbGenericService<Wishlist> _dbService;


        public WishlistService(DbGenericService<Wishlist> dbService)
        {
            _dbService = dbService;
            _wishlists = _dbService.GetObjectsAsync().Result.ToList();

            _dbService.SaveObjects(_wishlists);
        }

        public async Task AddWishlistAsync(Wishlist wishlist)
        {
            _wishlists.Add(wishlist);
            await _dbService.AddObjectAsync(wishlist);
        }
        public async Task<Wishlist> DeleteWishlistAsync(int? wishlistId)
        {
            var wishlistItem = _wishlists.FirstOrDefault(c => c.WishlistId == wishlistId);
            if (wishlistItem != null)
            {
                _wishlists.Remove(wishlistItem);
                await _dbService.DeleteObjectAsync(wishlistItem);
            }

            return wishlistItem;
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
        public List<Wishlist> GetWishlistProducts()
        {
            return _wishlists = _dbService.GetObjectsAsync().Result.ToList();
        }

        public List<Wishlist> GetWishlistByUserId(int userId)
        {
            return _wishlists.Where(w => w.userId == userId).ToList();
        }
    }
}


