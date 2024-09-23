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
    // Controller to manage shopping carts, requires authorization
    [Authorize]
    public class CartsController : Controller
    {
        private readonly DKTechContext _context;

        // Constructor to inject the database context
        public CartsController(DKTechContext context)
        {
            _context = context;
        }

        // GET: Carts - Displays a list of carts
        public async Task<IActionResult> Index()
        {
            var dKTechContext = _context.Cart.Include(c => c.Customer); // Include related customer data
            return View(await dKTechContext.ToListAsync()); // Return the cart list view
        }

        // GET: Carts/Details/5 - Displays details for a specific cart
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var cart = await _context.Cart
                .Include(c => c.Customer) // Include related customer data
                .FirstOrDefaultAsync(m => m.CartID == id); // Find cart by id
            if (cart == null)
            {
                return NotFound(); // Return 404 if cart not found
            }

            return View(cart); // Return the cart details view
        }

        // GET: Carts/Create - Displays the create cart form (admin only)
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            // Populate CustomerID select list for the dropdown
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID");
            return View(); // Return the create view
        }

        // POST: Carts/Create - Handles the submission of the create cart form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartID,Quantity,TotalPrice,CustomerID")] Cart cart)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(cart); // Add cart to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to index view
            }
            // Re-populate select list if model state is invalid
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID", cart.CustomerID);
            return View(cart); // Return the create view with validation errors
        }

        // GET: Carts/Edit/5 - Displays the edit form for a specific cart
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var cart = await _context.Cart.FindAsync(id); // Find cart by id
            if (cart == null)
            {
                return NotFound(); // Return 404 if cart not found
            }
            // Populate CustomerID select list for the dropdown
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID", cart.CustomerID);
            return View(cart); // Return the edit view
        }

        // POST: Carts/Edit/5 - Handles the submission of the edit form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartID,Quantity,TotalPrice,CustomerID")] Cart cart)
        {
            if (id != cart.CartID)
            {
                return NotFound(); // Return 404 if the id doesn't match
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart); // Update the cart in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartID)) // Check if the cart still exists
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
            // Re-populate select list if model state is invalid
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "CustomerID", "CustomerID", cart.CustomerID);
            return View(cart); // Return the edit view with validation errors
        }

        // GET: Carts/Delete/5 - Displays the delete confirmation for a specific cart
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var cart = await _context.Cart
                .Include(c => c.Customer) // Include related customer data
                .FirstOrDefaultAsync(m => m.CartID == id); // Find cart by id
            if (cart == null)
            {
                return NotFound(); // Return 404 if cart not found
            }

            return View(cart); // Return the delete confirmation view
        }

        // POST: Carts/Delete/5 - Handles the deletion of a specific cart
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cart = await _context.Cart.FindAsync(id); // Find cart by id
            if (cart != null)
            {
                _context.Cart.Remove(cart); // Remove cart from the context
            }

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to index view
        }

        // Helper method to check if a cart exists by id
        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartID == id); // Return true if cart exists
        }
    }
}
