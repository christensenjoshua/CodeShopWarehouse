using CodeShopWarehouse.Data;
using CodeShopWarehouse.Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace CodeShopWarehouse.Business.Test
{
    [TestClass]
    public class OrdersServiceTests
    {
        [TestMethod]
        public void UnresolvedFillOrdersCanBeRetrieved()
        {
            var mockOrdersRepo = Substitute.For<IOrdersRepo>();
            var ordersService = new OrdersService(mockOrdersRepo);

            try
            {
                var expectedOrders = ordersService.GetUnProcessedOrders();
            }
            catch (Exception ex)
            {
                Assert.Fail("You were unable to get orders!");
            }
        }
        [TestMethod]
        public void CannotProcessAlreadyProcessedOrder()
        {
            Order aClosedOrder = new Order
            {
                Id = 100,
                ProcessedAt = DateTimeOffset.Now
            };
            var mockOrdersRepo = Substitute.For<IOrdersRepo>();
            mockOrdersRepo.GetOrderById(aClosedOrder.Id).Returns(aClosedOrder);
            var ordersService = new OrdersService(mockOrdersRepo);
            try
            {
                ordersService.ProcessOrder(aClosedOrder.Id);
            }
            catch(Exception ex)
            {
                Assert.AreEqual("This order is already processed!", ex.Message);
                return;
            }
            Assert.Fail("Shouldn't have gotten past here!!!");
        }

        [TestMethod]
        public void CanProcessAnUnProcessedOrder()
        {
            Order anOpenOrder = new Order
            {
                Id = 500,
            };
            var mockOrdersRepo = Substitute.For<IOrdersRepo>();
            mockOrdersRepo.GetOrderById(anOpenOrder.Id).Returns(anOpenOrder);
            var ordersService = new OrdersService(mockOrdersRepo);
            try
            {
                ordersService.ProcessOrder(anOpenOrder.Id);
            }
            catch(Exception ex)
            {
                Assert.Fail("You got an exception");
            }
        }
    }
}
