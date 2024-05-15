using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Services
{
    public class WishlistService : DbGenericService<Wishlist>//, IWishlistService
    {
        //public List<Wishlist> _wishlist;
        //public DbGenericService<Wishlist> _dbService;

        //public WishlistService()
        //{
        //}
        //private readonly DbContext _context;

        //public WishlistService(DbContext context) : base(context)
        //{
        //    _context = context;
        //}

        //public async Task<Wishlist> OnGetWishlistItemsById(int wishlistId)
        //{
        //    return await _context.Wishlist
        //                         .Include(w => w.Items) // Include WishlistItems in the query
        //                         .FirstOrDefaultAsync(w => w.Id == wishlistId);
        //}

        
        //Skal kigges på 
        //public WishlistService(DbGenericService<Wishlist> dbService)
        //{
        //    _dbService = dbService;
        //    _wishlist = _dbService.GetObjectsAsync().Result.ToList();
        //}

        //public void AddToWishlist(Wishlist wishlist)
        //{
        //    _wishlist.Add(wishlist);
        //    _dbService.AddObjectAsync(wishlist);
        //}
    }
}
