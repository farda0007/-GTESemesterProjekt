using ÆGTESemesterProjekt.EFDbContext;
using ÆGTESemesterProjekt.Models;
using ÆGTESemesterProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ÆGTESemesterProjekt.Pages.Wishlist
{
    public class WishlistProductModel : PageModel
    {
        private IProductService _productService;
        public UserService _userService;
        public WishlistService _wishlistService;

        public Models.User user { get; set; }
        public Product product { get; set; }
        public Models.Wishlist wishlist { get; set; } = new Models.Wishlist();

        public WishlistProductModel(IProductService productService, UserService userService, WishlistService wishlistService)
        {
            _productService = productService;
            _userService = userService;
            _wishlistService = wishlistService;
        }

        public List<Models.Wishlist> Wishlist;

        public void OnGet()
        {
            var user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            Wishlist = new List<Models.Wishlist>();
        }


        public List<Models.Wishlist> OnGetWishlistItemsByUserIdAsync(int userId)
        {
            Models.User user;
            using (var context = new ProductDbContext())
            {
                return context.Wishlist
                .Where(w => w.userId == userId)
                .Select(w => new Models.Wishlist
                {
                    ProductId = w.ProductId,
                   //Product = w.Product.ProductName,
                }).ToList();
            }
        }

        public IActionResult OnPostAddToWishlist (int productId, int userId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = _productService.GetProduct(productId);
            var user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
            if (user == null || product == null)
            {
                return Page();
            }

            //var wishlist = _wishlistService.OnGetWishlistItemsByUserId(userId);
            //if (wishlist == null)
            //{
            //    wishlist = new Wishlist { UserId = user.UserId };
            //}


            //wishlist.Products.Add(product); //Istansiering af wishlist
            //_wishlistService.AddToWishlist(wishlist);

            //wishlist.userId = user.UserId;
            //wishlist.ProductId = product.Id;
            //_wishlistService.AddToWishlist(wishlist);

            return RedirectToPage("/Products/GetAllProducts");
        }

        //public IActionResult OnPost(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    product = _productService.GetProduct(id);
        //    user = _userService.GetUserByUserName(HttpContext.User.Identity.Name);
        //    wishlist.userId = user.UserId;
        //    wishlist.ProductId = product.Id;
        //    _wishlistService.AddToWishlist(wishlist);
        //    return RedirectToPage("/Products/GetAllProducts");
        //}    
    }
}
