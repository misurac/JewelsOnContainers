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
                return $"{baseUri}events{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }

            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
