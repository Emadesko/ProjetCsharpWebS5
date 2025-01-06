using Microsoft.AspNetCore.Mvc;
using ProjetCsharpWebS5.Models;
using System.Diagnostics;

namespace ProjetCsharpWebS5.Controllers
{
    public class LivreurController : Controller
    {
        private readonly ILogger<LivreurController> _logger;

        public LivreurController(ILogger<LivreurController> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
