using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Infrastructure;
using WebMvc1.Models.OrderModels;

namespace WebMvc1.Services
{
    public class OrderService : IOrderService
    {
        private IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly ILogger _logger;

        public OrderService(IConfiguration config, IHttpContextAccessor httpContextAccesor,
            IHttpClient httpClient, ILoggerFactory logger)
        {
            _remoteServiceBaseUrl = $"{config["OrderUrl"]}/api/orders";
            _config = config;
            _httpContextAccesor = httpContextAccesor;
            _apiClient = httpClient;
            _logger = logger.CreateLogger<OrderService>();
        }

        public async Task<int> CreateOrder(Order order)
        {
            var token = await GetUserTokenAsync();

            var addNewOrderUri = ApiPath.Order.AddNewOrder(_remoteServiceBaseUrl);
            _logger.LogDebug(" OrderUri " + addNewOrderUri);

            var response = await _apiClient.PostAsync(addNewOrderUri, order, token);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creating order, try later.");
            }

            var jsonString = response.Content.ReadAsStringAsync();

            jsonString.Wait();
            _logger.LogDebug("response " + jsonString);
            dynamic data = JObject.Parse(jsonString.Result);
            string value = data.orderId;
            return Convert.ToInt32(value);
        }

        async public Task<Order> GetOrder(string id)
        {
            var token = await GetUserTokenAsync();
            var getOrderUri = ApiPath.Order.GetOrder(_remoteServiceBaseUrl, id);

            var dataString = await _apiClient.GetStringAsync(getOrderUri, token);
            _logger.LogInformation("DataString: " + dataString);
            var response = JsonConvert.DeserializeObject<Order>(dataString);

            return response;
        }

        public async Task<List<Order>> GetOrders()
        {
            var token = await GetUserTokenAsync();
            var allOrdersUri = ApiPath.Order.GetOrders(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(allOrdersUri, token);
            var response = JsonConvert.DeserializeObject<List<Order>>(dataString);

            return response;
        }

        async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;

            return await context.GetTokenAsync("access_token");
        }
    }
}
