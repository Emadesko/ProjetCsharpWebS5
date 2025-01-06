using Microsoft.AspNetCore.Mvc;
using ProjetCsharpWebS5.Models;
using ProjetCsharpWebS5.Services;
using System.Diagnostics;

namespace ProjetCsharpWebS5.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger,IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index(int page =1 , int pageSize =10)
        {
            var Users = await _userService.GetDatasByPaginate(page,pageSize);
            return View(Users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Login, Password, Role")] User user)
        {
            if (ModelState.IsValid)
            {
                var userAdded = await _userService.Create(user);
                TempData["Message"] = "User créé avec succès!";
                return RedirectToAction(nameof(Index));
            }
            return View(user);
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
