using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext eventContext)
        {
            eventContext.Database.Migrate();
            if (!eventContext.EventTypes.Any())
            {
                eventContext.EventTypes.AddRange(GetEventTypes());
                eventContext.SaveChanges();
            }
            if (!eventContext.Events.Any())
            {
                eventContext.Events.AddRange(GetEvents());
                eventContext.SaveChanges();
            }
        }

        private static IEnumerable<Event> GetEvents()
        {
            return new List<Event>()
            {
            new Event { EventTypeId = 1, Description = "We will party like it's 1995", Name = "Sam's Birthday", Location = "Colorado Springs", Date = "March 1st, 2021", Price = 0 },
            new Event { EventTypeId = 2, Description = "Includes 3 courses and dessert", Name = "Cooking class", Location = "100 E State St", Date = "May 7th, 2021", Price = 75 },
            new Event { EventTypeId = 3, Description = "Guided meditation with Libby", Name = "Meditation", Location = "Online", Date = "April 25th, 2021", Price = 10 },
            new Event { EventTypeId = 4, Description = "In the Drake Hotel", Name = "Jamie's Wedding", Location = "Downtown Chicago", Date = "October 19th, 2021", Price = 0 }
            };
        }

        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                new EventType
                {
                    Type = "Ceremony"
                },
                new EventType
                {
                    Type = "Party"
                },
                new EventType
                {
                    Type = "Education"
                },
                new EventType
                {
                    Type = "Virtual"
                }

            };
        }
    }
}
