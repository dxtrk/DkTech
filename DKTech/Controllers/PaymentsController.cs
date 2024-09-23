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
    // Allow access only to users with the Admin role
    [Authorize(Roles = "Admin")]
    public class PaymentsController : Controller
    {
        private readonly DKTechContext _context;

        // Constructor to inject the database context
        public PaymentsController(DKTechContext context)
        {
            _context = context;
        }

        // GET: Payments - Displays a list of all payments
        public async Task<IActionResult> Index()
        {
            var dKTechContext = _context.Payment.Include(p => p.Order); // Include related order data
            return View(await dKTechContext.ToListAsync()); // Return the list of payments to the view
        }

        // GET: Payments/Details/5 - Displays details for a specific payment
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var payment = await _context.Payment
                .Include(p => p.Order) // Include related order data
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound(); // Return 404 if the payment is not found
            }

            return View(payment); // Return the payment details view
        }

        // GET: Payments/Create - Displays the create payment form
        public IActionResult Create()
        {
            // Prepare a select list for orders to associate with the payment
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID");
            return View(); // Return the create view
        }

        // POST: Payments/Create - Handles form submission to create a new payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentID,CustomerID,PayAmount,PayMethod,PayDate,OrderID")] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(payment); // Add the new payment to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the index action
            }
            // Prepare the order select list again if model state is invalid
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID", payment.OrderID);
            return View(payment); // Return the create view with the payment model
        }

        // GET: Payments/Edit/5 - Displays the edit form for a specific payment
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var payment = await _context.Payment.FindAsync(id); // Find the payment by ID
            if (payment == null)
            {
                return NotFound(); // Return 404 if the payment is not found
            }
            // Prepare the order select list for the edit view
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID", payment.OrderID);
            return View(payment); // Return the edit view with the payment model
        }

        // POST: Payments/Edit/5 - Handles form submission to edit an existing payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentID,CustomerID,PayAmount,PayMethod,PayDate,OrderID")] Payment payment)
        {
            if (id != payment.PaymentID)
            {
                return NotFound(); // Return 404 if the ID doesn't match
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment); // Update the payment in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Check if the payment still exists and handle concurrency
                    if (!PaymentExists(payment.PaymentID))
                    {
                        return NotFound(); // Return 404 if the payment is not found
                    }
                    else
                    {
                        throw; // Rethrow if there's another issue
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to the index action
            }
            // Prepare the order select list again if model state is invalid
            ViewData["OrderID"] = new SelectList(_context.Order, "OrderID", "OrderID", payment.OrderID);
            return View(payment); // Return the edit view with the payment model
        }

        // GET: Payments/Delete/5 - Displays the delete confirmation page for a specific payment
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var payment = await _context.Payment
                .Include(p => p.Order) // Include related order data
                .FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound(); // Return 404 if the payment is not found
            }

            return View(payment); // Return the delete confirmation view
        }

        // POST: Payments/Delete/5 - Handles the deletion of a payment
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context.Payment.FindAsync(id);
            if (payment != null)
            {
                _context.Payment.Remove(payment); // Remove the payment from the context
            }

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to the index action
        }

        // Helper method to check if a payment exists
        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentID == id); // Check if the payment exists in the database
        }
    }
}
