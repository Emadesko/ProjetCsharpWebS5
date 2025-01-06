using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetCsharpWebS5.Models;
using ProjetCsharpWebS5.Services;
using System.Diagnostics;

namespace ProjetCsharpWebS5.Controllers
{
    public class AuthentificationController : Controller
    {
        private readonly ILogger<AuthentificationController> _logger;

        private readonly IUserService _userService;
        private readonly IClientService _clientService;

        public AuthentificationController(ILogger<AuthentificationController> logger,IUserService userService, IClientService clientService)
        {
            _logger = logger;
            _userService = userService;
            _clientService = clientService;
        }

        public IActionResult Login()
        {
            return View(new LoginViewModel{});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userService.GetUserByLogin(model.Login);

            if (user == null || !user.VerifyPassword(model.Password))
            {
                ModelState.AddModelError(string.Empty, "Login ou mot de passe incorrect");
                return View(model);
            }

            // Créer une session utilisateur
            // HttpContext.Session.SetString("UserConnect", JsonConvert.SerializeObject(user));

            // Rediriger l'utilisateur en fonction de son rôle
            if (user.Role == "Client")
            {
                // HttpContext.Session.SetString("Client", JsonConvert.SerializeObject(await _clientService.GetClientByLogin(user.Login)));
                return RedirectToAction("Index", "Client");
            }
            else if (user.Role == "Secretaire")
            {
                return RedirectToAction("Index", "User");
            }
            else if (user.Role == "RespStock")
            {
                return RedirectToAction("Index", "Produit");
            }
            else if (user.Role == "Comptable")
            {
                return RedirectToAction("Index", "Client");
            }

            // Redirection par défaut
            return RedirectToAction("Index", "Home");
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
