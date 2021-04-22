using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Models;
using WebMvc1.Services;

namespace WebMvc1.ViewComponents
{
    public class CartList:ViewComponent
    {
        private readonly ICartService _cartSvc;

        public CartList(ICartService cartSvc) => _cartSvc = cartSvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new Models.Cart();
            try
            {
                vm = await _cartSvc.GetCart(user);

                return View(vm);
            }
            catch (BrokenCircuitException)
            {
                ViewBag.IsBasketInoperative = true;
                TempData["BasketInoperativeMsg"] = "Basket Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
            }

            return View(vm);

        }
    }
}
