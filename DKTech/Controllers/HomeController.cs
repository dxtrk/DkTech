using DKTech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DKTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PCandLaptops()
        {
            return View();
        }

        public IActionResult PCPartss()
        {
            return View();
        }

        public IActionResult PCPeripheralsandAccessories()
        {
            return View();
        }

        public IActionResult ContactUss()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult ProductPCParts()
        {
            return View();
        }

        public IActionResult ProductPCPeripheralsandAccessories()
        {
            return View();
        }







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
