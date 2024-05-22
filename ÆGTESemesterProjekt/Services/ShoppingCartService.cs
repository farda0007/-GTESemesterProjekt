﻿using ÆGTESemesterProjekt.Models;

namespace ÆGTESemesterProjekt.Services
{
    public class ShoppingCartService
    {
        public List<ShoppingCart> _cartList;
        public DbGenericService<ShoppingCart> _dbService;
        public DbGenericService<Product> _productService;

        public ShoppingCartService()
        {
        }

        public ShoppingCartService(DbGenericService<ShoppingCart> dbService, DbGenericService<Product> productService)
        {
            _dbService = dbService;
            _productService = productService;
            _cartList = _dbService.GetObjectsAsync().Result.ToList();
        }
            
        public void AddCart(ShoppingCart cart)
        {
            _cartList.Add(cart);
            _dbService.AddObjectAsync(cart);
        }
        public List<ShoppingCart> GetCartProducts()
        {
            return _cartList = _dbService.GetObjectsAsync().Result.ToList();
        }
        public async Task ClearCartAsync(int userId)
        {
            var userCartItems = _cartList.Where(c => c.userId == userId).ToList();
            foreach (var cartItem in userCartItems)
            {
                _cartList.Remove(cartItem);
                await _dbService.DeleteObjectAsync(cartItem);
            }
        }
        
    }
}
