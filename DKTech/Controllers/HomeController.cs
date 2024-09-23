using DKTech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace DKTech.Controllers
{
    // Allows anonymous access to all actions in this controller
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor to inject the logger service
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: / - Displays the home page
        public IActionResult Index()
        {
            return View(); // Return the Index view
        }

        // GET: /Home/Privacy - Displays the privacy policy page
        public IActionResult Privacy()
        {
            return View(); // Return the Privacy view
        }

        // GET: /Home/PCandLaptops - Displays the PCs and laptops page
        public IActionResult PCandLaptops()
        {
            return View(); // Return the PC and Laptops view
        }

        // GET: /Home/PCPartss - Displays the PC parts page
        public IActionResult PCPartss()
        {
            return View(); // Return the PC Parts view
        }

        // GET: /Home/PCPeripheralsandAccessories - Displays the peripherals and accessories page
        public IActionResult PCPeripheralsandAccessories()
        {
            return View(); // Return the PC Peripherals and Accessories view
        }

        // GET: /Home/ContactUss - Displays the contact page
        public IActionResult ContactUss()
        {
            return View(); // Return the Contact Us view
        }

        // GET: /Home/Product - Displays the product listing page
        public IActionResult Product()
        {
            return View(); // Return the Product view
        }

        // GET: /Home/ProductPCParts - Displays the PC parts product page
        public IActionResult ProductPCParts()
        {
            return View(); // Return the Product PC Parts view
        }

        // GET: /Home/ProductPCPeripheralsandAccessories - Displays the PC peripherals product page
        public IActionResult ProductPCPeripheralsandAccessories()
        {
            return View(); // Return the Product PC Peripherals view
        }

        // GET: /Home/Cart - Displays the shopping cart page
        public IActionResult Cart()
        {
            return View(); // Return the Cart view
        }

        // GET: /Home/Error - Displays the error page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Create an ErrorViewModel with the current request ID for debugging
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
