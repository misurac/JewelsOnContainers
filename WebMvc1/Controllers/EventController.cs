using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Services;
using WebMvc1.ViewModels;

namespace WebMvc1.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? typesFilterApplied)
        {
            
            var itemsOnPage = 2;

            
            var events = await _service.GetEventItemsAsync(page ?? 0, itemsOnPage, typesFilterApplied);

            var vm = new EventIndexViewModel
            {
                EventItems = events.Data,
                Types = await _service.GetTypesAsync(),
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0, 
                    ItemsPerPage = events.PageSize,
                    TotalItems = events.Count,
                    TotalPages = (int)Math.Ceiling((decimal)events.Count / itemsOnPage)
                },
                TypesFilterApplied = typesFilterApplied ?? 0
            };

            return View(vm);
        }
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}
