using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Models;

namespace WebMvc1.Services
{
    public interface IEventService
    {
        Task<EventPageInfo> GetEventItemsAsync(int page, int size, int? type);
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
    }
}
