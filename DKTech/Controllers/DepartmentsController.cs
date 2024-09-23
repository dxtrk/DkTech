using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DKTech.Areas.Identity.Data;
using DKTech.Models;
using Microsoft.AspNetCore.Authorization;

namespace DKTech.Controllers
{
    // Controller to manage department operations, accessible only by Admin role
    [Authorize(Roles = "Admin")]
    public class DepartmentsController : Controller
    {
        private readonly DKTechContext _context;

        // Constructor to inject the database context
        public DepartmentsController(DKTechContext context)
        {
            _context = context;
        }

        // GET: Departments - Displays a list of departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Department.ToListAsync()); // Return the department list view
        }

        // GET: Departments/Details/5 - Displays details for a specific department
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.DepartmentID == id); // Find department by id
            if (department == null)
            {
                return NotFound(); // Return 404 if department not found
            }

            return View(department); // Return the department details view
        }

        // GET: Departments/Create - Displays the create department form
        public IActionResult Create()
        {
            return View(); // Return the create view
        }

        // POST: Departments/Create - Handles the submission of the create form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID,DepartmentName")] Department department)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(department); // Add new department to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(Index)); // Redirect to index view
            }
            return View(department); // Return the create view with validation errors
        }

        // GET: Departments/Edit/5 - Displays the edit form for a specific department
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var department = await _context.Department.FindAsync(id); // Find department by id
            if (department == null)
            {
                return NotFound(); // Return 404 if department not found
            }
            return View(department); // Return the edit view
        }

        // POST: Departments/Edit/5 - Handles the submission of the edit form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentID,DepartmentName")] Department department)
        {
            if (id != department.DepartmentID)
            {
                return NotFound(); // Return 404 if the id doesn't match
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(department); // Update the department in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentID)) // Check if the department still exists
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
            return View(department); // Return the edit view with validation errors
        }

        // GET: Departments/Delete/5 - Displays the delete confirmation for a specific department
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return 404 if id is null
            }

            var department = await _context.Department
                .FirstOrDefaultAsync(m => m.DepartmentID == id); // Find department by id
            if (department == null)
            {
                return NotFound(); // Return 404 if department not found
            }

            return View(department); // Return the delete confirmation view
        }

        // POST: Departments/Delete/5 - Handles the deletion of a specific department
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Department.FindAsync(id); // Find department by id
            if (department != null)
            {
                _context.Department.Remove(department); // Remove department from the context
            }

            await _context.SaveChangesAsync(); // Save changes to the database
            return RedirectToAction(nameof(Index)); // Redirect to index view
        }

        // Helper method to check if a department exists by id
        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.DepartmentID == id); // Return true if department exists
        }
    }
}
