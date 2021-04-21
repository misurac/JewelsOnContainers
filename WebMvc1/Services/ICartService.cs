using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Models;

namespace WebMvc1.Services
{
    interface ICartService
    {
        Task<Cart> GetCart(ApplicationUser user);
        Task AddItemToCart(ApplicationUser user, CartItem product);
        Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities);
        Task ClearCart(ApplicationUser user);
    }
}
