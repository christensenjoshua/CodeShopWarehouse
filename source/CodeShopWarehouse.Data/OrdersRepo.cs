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
        IEnumerable<Order> GetUnProcessedOrders();
        IEnumerable<Order> GetAllOrders();
        void CreateOrder(Order o);
        void ProcessOrder(Order o);
    }
    public class OrdersRepo : IOrdersRepo
    {
        private readonly IDbConnection _db;

        public OrdersRepo(IDbConnection db)
        {
            _db = db;
        }

        public Order GetOrderById(int id)
        {
            return new Order
            {
                Id = id,
                Name = "This is a Name!",
                QuantityMod = -5,
                CreatedAt = DateTimeOffset.Now.AddDays(-7)
            };
        }

        public IEnumerable<Order> GetUnProcessedOrders()
        {
            return new List<Order>
            {
                GetOrderById(1),
                GetOrderById(2),
                GetOrderById(3)
            };
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return new List<Order>
            {
                GetOrderById(10),
                GetOrderById(11),
                GetOrderById(12)
            };
        }

        public void CreateOrder(Order o)
        {
            Console.WriteLine($"I created order {o.Name}!");
        }

        public void ProcessOrder(Order o)
        {
            Console.WriteLine($"I updated {o.Name}!");
        }
    }

}
