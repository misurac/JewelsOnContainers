﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc1.Infrastructure
{
    public class ApiPath
    {
        public static class Events
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }

            public static string GetAllEvents(string baseUri, int page, int take, int? type)
            {
                var filterQs = string.Empty;
                if (type.HasValue)
                {
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "null";
                    filterQs = $"/type/{typeQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }
    }
}