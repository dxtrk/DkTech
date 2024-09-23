using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DKTech.Areas.Identity.Data;
using DKTech.Models;

namespace DKTech.Controllers
{
    // Controller to manage customer operations
    public class CustomersController : Controller
    {
        private readonly DKTechContext _context;

        // Constructor to inject the database context
        public CustomersController(DKTechContext context)
        {
            _context = context;
        }

        // GET: Customers - Displays a list of customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync()); // Return the customer list view
        }

        // GET: Customers/Details/5 - Displays details for a specific customer
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerID == id); // Find customer by id
            if (customer == null)
            {
                return NotFound(); // Return 404 if customer not found
            }

            return View(customer); // Return the customer details view
        }

        // GET: Customers/Create - Displays the create customer form
        public IActionResult Create()
        {
            return View(); // Return the create view
        }

        // POST: Customers/Create - Handles the submission of the create form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerID,Last_Name,FirstMidName,Email,OrderDate")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(customer); // Add new customer to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to index view
            }
            return View(customer); // Return the create view with validation errors
        }

        // GET: Customers/Edit/5 - Displays the edit form for a specific customer
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var customer = await _context.Customer.FindAsync(id); // Find customer by id
            if (customer == null)
            {
                return NotFound(); // Return 404 if customer not found
            }
            return View(customer); // Return the edit view
        }

        // POST: Customers/Edit/5 - Handles the submission of the edit form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,Last_Name,FirstMidName,Email,OrderDate")] Customer customer)
        {
            if (id != customer.CustomerID)
            {
                return NotFound(); // Return 404 if the id doesn't match
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer); // Update the customer in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerID)) // Check if the customer still exists
                    {
                        return NotFound(); // Return 404 if it doesn't
                    }
                    else
                    {
                        throw; // Re-throw exception for unhandled cases
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to index view
            }
            return View(customer); // Return the edit view with validation errors
        }

        // GET: Customers/Delete/5 - Displays the delete confirmation for a specific customer
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.CustomerID == id); // Find customer by id
            if (customer == null)
            {
                return NotFound(); // Return 404 if customer not found
            }

            return View(customer); // Return the delete confirmation view
        }

        // POST: Customers/Delete/5 - Handles the deletion of a specific customer
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id); // Find customer by id
            if (customer != null)
            {
                _context.Customer.Remove(customer); // Remove customer from the context
            }

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to index view
        }

        // Helper method to check if a customer exists by id
        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerID == id); // Return true if customer exists
        }
    }
}
