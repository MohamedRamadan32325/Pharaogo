using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication7.Models;
using WebApplication7.ViewModels;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
		public IActionResult LoadLoginModal()
		{
			return PartialView("_LoginModal");
		}
		public IActionResult LoadRegisterModal()
		{
			return PartialView("_RegisterModal");
		}

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
