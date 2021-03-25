using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Data;
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
            var events = await _context.Events
                .OrderBy(e => e.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(events);
        }
    }
}
