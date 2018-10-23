using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeShopWarehouse.Entities.Models;
using CodeShopWarehouse.Web.Models;
using CodeShopWarehouse.Business;

namespace CodeShopWarehouse.Web.Controllers
{
    public class OrdersViewController : Controller
    {
        OrdersService _service;

        public OrdersViewController(OrdersService service)
        {
            _service = service;
        }

        // GET: OrdersView
        public IActionResult Index()
        {
            return View(_service.GetAllOrders());
        }

        [HttpPost]
        public IActionResult Process([FromForm]int id)
        {
            _service.ProcessOrder(id);
            return RedirectToAction("Index");
        }
        // GET: OrdersView/Details/5
        public IActionResult Details(int id)
        {
            Order order = _service.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: OrdersView/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: OrdersView/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,QuantityMod,CreatedAt,ProcessedAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                _service.CreateOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        //// GET: OrdersView/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Order.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(order);
        //}

        //// POST: OrdersView/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,QuantityMod,CreatedAt,ProcessedAt")] Order order)
        //{
        //    if (id != order.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(order);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OrderExists(order.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(order);
        //}

        //// GET: OrdersView/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = await _context.Order
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //// POST: OrdersView/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var order = await _context.Order.FindAsync(id);
        //    _context.Order.Remove(order);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool OrderExists(int id)
        //{
        //    return _context.Order.Any(e => e.Id == id);
        //}
    }
}
