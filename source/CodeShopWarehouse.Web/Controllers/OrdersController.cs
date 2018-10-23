using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeShopWarehouse.Web.Models;
using CodeShopWarehouse.Business;
using CodeShopWarehouse.Entities.Models;

namespace CodeShopWarehouse.Web.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly OrdersService _ordersService;

        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_ordersService.GetAllOrders());
        }

        [HttpGet("&unprocessed")]
        public IActionResult GetUnProcessedOrders()
        {
            return Ok(_ordersService.GetUnProcessedOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(_ordersService.GetOrderById(id));
        }
        [HttpPost("create")]
        public IActionResult CreateOrder([FromBody]Order o)
        {
            _ordersService.CreateOrder(o);
            return Ok();
        }
        [HttpPost("process")]
        public IActionResult ProcessOrder([FromBody]Order o)
        {
            return Ok(_ordersService.ProcessOrder(o));
        }
    }
}
