using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Models.OrderModels;

namespace WebMvc1.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task<Order> GetOrder(string orderId);
        Task<int> CreateOrder(Order order);
    }
}
