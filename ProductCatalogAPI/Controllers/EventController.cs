using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.Domain;
using ProductCatalogAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        public EventController(EventContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery]int pageIndex = 0, 
            [FromQuery]int pageSize = 2)
        {
            var eventsCount = _context.Events.LongCountAsync();
            var events = await _context.Events
                .OrderBy(e => e.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var model = new PaginatedItemViewModel<Event>
            {
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount.Result,
                Data = events
            };
            return Ok(model);
        }

        [HttpGet("[action]/type/{catalogTypeId}")]
        public async Task<IActionResult> Items(int? eventTypeId,
               [FromQuery] int pageIndex = 0,
               [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<Event>)_context.Events;
            if (eventTypeId.HasValue)
            {
                query = query.Where(c => c.EventTypeId == eventTypeId);
            }

            var eventsCount = query.LongCountAsync();
            var events = await query
                    .OrderBy(c => c.Name)
                    .Skip(pageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            var model = new PaginatedItemViewModel<Event>
            {
                PageIndex = pageIndex,
                PageSize = events.Count,
                Count = eventsCount.Result,
                Data = events
            };

            return Ok(model);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

    }
}
