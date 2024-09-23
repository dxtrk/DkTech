using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DKTech.Areas.Identity.Data;
using DKTech.Models;
using Microsoft.AspNetCore.Authorization;

namespace DKTech.Controllers
{
    // Only users with the Admin role can access this controller
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly DKTechContext _context;

        // Constructor to inject the database context
        public OrdersController(DKTechContext context)
        {
            _context = context;
        }

        // GET: Orders - Displays a list of orders
        public async Task<IActionResult> Index()
        {
            var dKTechContext = _context.Order.Include(o => o.Customer); // Include related customer data
            return View(await dKTechContext.ToListAsync()); // Return the list of orders to the view
        }

        // GET: Orders/Details/5 - Displays details for a specific order
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var order = await _context.Order
                .Include(o => o.Customer) // Include related customer data
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound(); // Return 404 if the order is not found
            }

            return View(order); // Return the order details view
        }

        // GET: Orders/Create - Displays the create order form
        public IActionResult Create()
        {
            // Prepare a select list for customers to associate with the order
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID");
            return View(); // Return the create view
        }

        // POST: Orders/Create - Handles form submission to create a new order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,CustomerID,OrderDate,PickupDate")] Order order)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(order); // Add the new order to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the index action
            }
            // Prepare the customer select list again if model state is invalid
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", order.CustomerID);
            return View(order); // Return the create view with the order model
        }

        // GET: Orders/Edit/5 - Displays the edit form for a specific order
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var order = await _context.Order.FindAsync(id); // Find the order by ID
            if (order == null)
            {
                return NotFound(); // Return 404 if the order is not found
            }
            // Prepare the customer select list for the edit view
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", order.CustomerID);
            return View(order); // Return the edit view with the order model
        }

        // POST: Orders/Edit/5 - Handles form submission to edit an existing order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,CustomerID,OrderDate,PickupDate")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound(); // Return 404 if the ID doesn't match
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(order); // Update the order in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Check if the order still exists and handle concurrency
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound(); // Return 404 if the order is not found
                    }
                    else
                    {
                        throw; // Rethrow if there's another issue
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to the index action
            }
            // Prepare the customer select list again if model state is invalid
            ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID", order.CustomerID);
            return View(order); // Return the edit view with the order model
        }

        // GET: Orders/Delete/5 - Displays the delete confirmation page for a specific order
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var order = await _context.Order
                .Include(o => o.Customer) // Include related customer data
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound(); // Return 404 if the order is not found
            }

            return View(order); // Return the delete confirmation view
        }

        // POST: Orders/Delete/5 - Handles the deletion of an order
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order); // Remove the order from the context
            }

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to the index action
        }

        // Helper method to check if an order exists
        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id); // Check if the order exists in the database
        }
    }
}
