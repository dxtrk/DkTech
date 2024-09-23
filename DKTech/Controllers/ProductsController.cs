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
    // Allow access to authenticated users
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly DKTechContext _context;

        // Constructor to inject the database context
        public ProductsController(DKTechContext context)
        {
            _context = context;
        }

        // GET: Products - Displays a list of products
        public async Task<IActionResult> Index()
        {
            var dKTechContext = _context.Product.Include(p => p.Department); // Include related department data
            return View(await dKTechContext.ToListAsync()); // Return the list of products to the view
        }

        // GET: Products/Details/5 - Displays details for a specific product
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var product = await _context.Product
                .Include(p => p.Department) // Include related department data
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound(); // Return 404 if the product is not found
            }

            return View(product); // Return the product details view
        }

        // Only users with the Admin role can access the Create action
        [Authorize(Roles = "Admin")]
        // GET: Products/Create - Displays the create product form
        public IActionResult Create()
        {
            // Prepare a select list for departments to associate with the product
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentName");
            return View(); // Return the create view
        }

        // POST: Products/Create - Handles form submission to create a new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,DepartmentID,ListPrice,Quantity")] Product product)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(product); // Add the new product to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to the index action
            }
            // Prepare the department select list again if model state is invalid
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentName", product.DepartmentID);
            return View(product); // Return the create view with the product model
        }

        // GET: Products/Edit/5 - Displays the edit form for a specific product
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var product = await _context.Product.FindAsync(id); // Find the product by ID
            if (product == null)
            {
                return NotFound(); // Return 404 if the product is not found
            }
            // Prepare the department select list for the edit view
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentName", product.DepartmentID);
            return View(product); // Return the edit view with the product model
        }

        // POST: Products/Edit/5 - Handles form submission to edit an existing product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,DepartmentID,ListPrice,Quantity")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound(); // Return 404 if the ID doesn't match
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(product); // Update the product in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Check if the product still exists and handle concurrency
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound(); // Return 404 if the product is not found
                    }
                    else
                    {
                        throw; // Rethrow if there's another issue
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirect to the index action
            }
            // Prepare the department select list again if model state is invalid
            ViewData["DepartmentID"] = new SelectList(_context.Department, "DepartmentID", "DepartmentName", product.DepartmentID);
            return View(product); // Return the edit view with the product model
        }

        // GET: Products/Delete/5 - Displays the delete confirmation page for a specific product
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if no ID is provided
            }

            var product = await _context.Product
                .Include(p => p.Department) // Include related department data
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound(); // Return 404 if the product is not found
            }

            return View(product); // Return the delete confirmation view
        }

        // POST: Products/Delete/5 - Handles the deletion of a product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product); // Remove the product from the context
            }

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to the index action
        }

        // Helper method to check if a product exists
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id); // Check if the product exists in the database
        }
    }
}
