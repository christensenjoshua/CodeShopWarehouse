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
            return _ordersRepo.GetUnProcessedOrders();
        }

        public void CreateOrder(Order o)
        {
            _ordersRepo.CreateOrder(o);
        }

        public void ProcessOrder(Order o)
        {
            Order dbOrder = _ordersRepo.GetOrderById(o.Id);
            if(dbOrder.ProcessedAt == null)
            {
                _ordersRepo.ProcessOrder(o);
            }
            else
            {
                throw new Exception("This order is already processed!");
            }
        }
    }
}
