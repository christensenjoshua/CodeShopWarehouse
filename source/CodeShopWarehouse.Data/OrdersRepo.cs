using CodeShopWarehouse.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CodeShopWarehouse.Data
{
    public interface IOrdersRepo
    {
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        void CreateOrder(Order o);
        Order ProcessOrder(Order o);
    }
    public class OrdersRepo : IOrdersRepo
    {
        private List<Order> allOrders = new List<Order>()
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
        private readonly IDbConnection _db;

        public OrdersRepo(IDbConnection db)
        {
            _db = db;
        }

        public Order GetOrderById(int id)
        {
            
            return allOrders.Find(x => x.Id == id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return allOrders;
        }

        public void CreateOrder(Order o)
        {
            allOrders.Add(o);
        }

        public Order ProcessOrder(Order o)
        {
            o.ProcessedAt = DateTimeOffset.Now;
            allOrders.RemoveAll(x => x.Id == o.Id);
            allOrders.Add(o);
            return o;
        }
    }

}
