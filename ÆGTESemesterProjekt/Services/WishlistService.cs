using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Services
{
    public class WishlistService : DbGenericService<Wishlist>
    {
        public List<Wishlist> _wishlist;
        public DbGenericService<Wishlist> _dbService;
        
        public WishlistService()
        {
        }

        public WishlistService(DbGenericService<Wishlist> dbService)
        {
            _dbService = dbService;
            _wishlist = _dbService.GetObjectsAsync().Result.ToList();
        }

        

        public void AddToWishlist(Wishlist wishlist)
        {
            _wishlist.Add(wishlist);
            _dbService.AddObjectAsync(wishlist);
        }
    }
}
