using CodeShopWarehouse.Data;
using CodeShopWarehouse.Entities.Models;
using System;
using System.Collections.Generic;

namespace CodeShopWarehouse.Business
{
    public class OrdersService
    {
        private readonly IOrdersRepo _ordersRepo;

        public OrdersService(IOrdersRepo ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }

        public Order GetOrderById(int id)
        {
            return _ordersRepo.GetOrderById(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersRepo.GetAllOrders();
        }

        public IEnumerable<Order> GetUnProcessedOrders()
        {
            IEnumerable<Order> allOrders = _ordersRepo.GetAllOrders();
            List<Order> unprocessed = new List<Order>();
            foreach(Order item in allOrders)
            {
                if(item.ProcessedAt == null)
                {
                    unprocessed.Add(item);
                }
            }
            return unprocessed;
        }

        public void ProcessOrder(int id)
        {
            ProcessOrder(GetOrderById(id));
        }

        public void CreateOrder(Order o)
        {
            _ordersRepo.CreateOrder(o);
        }

        private Order ProcessOrder(Order o)
        {
            if(o.ProcessedAt == null)
            {
                return _ordersRepo.ProcessOrder(o);
            }
            else
            {
                throw new Exception("This order is already processed!");
            }
        }
    }
}
