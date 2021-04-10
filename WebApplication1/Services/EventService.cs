using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Infrastructure;
using WebMvc1.Models;
using WebMvc1.Services;

namespace WebMvc.Services
{
    public class EventService : IEventService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;

        public EventService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["EventUrl"]}/api/event/";
            _client = client;
        }

        public async Task<EventPageInfo> GetEventItemsAsync(int page, int size, int? type)
        {
            var eventItemsUri = ApiPath.Events.GetAllEvents(_baseUrl, page, size, type);
            var dataString = await _client.GetStringAsync(eventItemsUri);
            return JsonConvert.DeserializeObject<EventPageInfo>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typeUri = ApiPath.Events.GetAllTypes(_baseUrl);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    });
            }
            return items;
        }
    }
}