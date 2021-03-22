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
            if (!eventContext.EventTypes.Any())
            {
                eventContext.EventTypes.AddRange(GetEventTypes())
            }
        }
    }
}
