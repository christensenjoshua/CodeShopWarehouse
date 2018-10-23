using CodeShopWarehouse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeShopWarehouse.Data
{
    public static class FakeData
    {
        public static List<Order> AllOrders = new List<Order>()
        {
            new Order {
                Id = 1,
                Name = "Order number One!!",
                QuantityMod = -1,
                CreatedAt = DateTimeOffset.Now.AddDays(-7),
                ProcessedAt = DateTimeOffset.Now
            },
            new Order {
                Id = 2,
                Name = "Two! This is a Name!",
                QuantityMod = 5,
                CreatedAt = DateTimeOffset.Now.AddDays(-7)
            },
            new Order {
                Id = 3,
                Name = "Three ! This is a Name!",
                QuantityMod = -10,
                CreatedAt = DateTimeOffset.Now.AddDays(-7)
            },
        };
    }
}
