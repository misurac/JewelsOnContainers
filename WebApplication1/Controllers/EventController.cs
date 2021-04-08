using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc1.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
