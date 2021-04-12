using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc1.Models;

namespace WebMvc1.ViewModels
{
    public class EventIndexViewModel
    {
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<Event> EventItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? TypesFilterApplied { get; set; }

    }
}
