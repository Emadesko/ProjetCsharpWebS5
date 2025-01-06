using Microsoft.AspNetCore.Mvc;
using ProjetCsharpWebS5.Models;
using ProjetCsharpWebS5.Services;
using System.Diagnostics;

namespace ProjetCsharpWebS5.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;

        private readonly IClientService _clientService;

        public ClientController(ILogger<ClientController> logger,IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index(int page =1 , int pageSize =10)
        {
            var clients = await _clientService.GetDatasByPaginate(page,pageSize);
            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Telephone,Adresse,User")] Client client)
        {
            if (ModelState.IsValid)
            {
                var clientAdded = await _clientService.Create(client);
                TempData["Message"] = "Client créé avec succès!";
                return RedirectToAction(nameof(Index));
            }
            return View(client);
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
