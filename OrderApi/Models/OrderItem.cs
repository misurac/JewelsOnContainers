﻿using OrderApi.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        //public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }

        public int Units { get; set; }
        public int ProductId { get; private set; }

        public OrderItem(int productId, string productName, decimal unitPrice, int units = 1)
        {
            if (units <= 0)
            {
                throw new OrderingDomainException("Invalid number of units");
            }

            ProductId = productId;
            UnitPrice = unitPrice;

            Units = units;
            //PictureUrl = pictureUrl;

            //public void SetPictureUri(string pictureUri)
            //{
            //    if (!String.IsNullOrWhiteSpace(pictureUri))
            //    {
            //        PictureUrl = pictureUri;
            //    }
        }
            public void AddUnits(int units)
            {
                if (units < 0)
                {
                    throw new OrderingDomainException("Invalid units");
                }

                Units += units;
            }
        

    }
}