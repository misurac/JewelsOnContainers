using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc1.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Date { get; set; }

        public int EventTypeId { get; set; }
        public string EventType { get; set; }
    }
}
