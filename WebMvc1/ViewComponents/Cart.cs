using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Models;
using WebMvc1.Services;
using WebMvc1.ViewModels;

namespace WebMvc1.ViewComponents
{
    public class Cart:ViewComponent
    {
        private readonly ICartService _cartSvc;

        public Cart(ICartService cartSvc) => _cartSvc = cartSvc;

        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new CartComponentViewModel();
            try
            {
                var cart = await _cartSvc.GetCart(user);

                vm.ItemsInCart = cart.Items.Count;
                vm.TotalCost = cart.Total();
                return View(vm);
            }
            catch (BrokenCircuitException)
            {
                ViewBag.IsBasketInoperative = true;
            }

            return View(vm);
        }
    }
}
