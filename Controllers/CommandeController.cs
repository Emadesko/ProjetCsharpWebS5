using Microsoft.AspNetCore.Mvc;
using ProjetCsharpWebS5.Dtos;
using ProjetCsharpWebS5.Models;
using ProjetCsharpWebS5.Services;
using System.Diagnostics;

namespace ProjetCsharpWebS5.Controllers
{
    public class CommandeController : Controller
    {
        private readonly ILogger<CommandeController> _logger;
        private readonly ICommandeService _commandeService;
        private readonly IProduitService _produitService;
        private readonly IClientService _clientService;

        public CommandeController(ILogger<CommandeController> logger, ICommandeService commandeService, IProduitService produitService, IClientService clientService)
        {
            _logger = logger;
            _commandeService = commandeService;
            _produitService = produitService;
            _clientService = clientService;
        }

        public async Task<IActionResult> Index(int page =1, int pageSize= 10)
        {
            var commandes = await _commandeService.GetDatasByPaginate(page, pageSize);
            return View(commandes);
        }
        public async Task<IActionResult> CommandeClient(int clientId, int page =1, int pageSize= 5)
        {
            var commandes = await _commandeService.GetCommandesByClientByPaginate(clientId, page, pageSize);
            return View(commandes);
        }

        public async Task<IActionResult> Create(int clientId, int page =1, int pageSize= 5)
        {
            var commandeCreateDto = new CommandeCreateDto{
                Produits = await _produitService.GetDatasByPaginate(page, pageSize),
                Client = await _clientService.GetById(clientId),
            };
            return View(commandeCreateDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CommandeCreateDto commandeCreateDto)
        {
            if (ModelState.IsValid)
            {
                Commande commande =new Commande {

                };
                // var commandeAdded = await _commandeService.Create(commande);
                TempData["Message"] = "Commande créé avec succès!";
                return RedirectToAction(nameof(Index));
            }
            return View(commandeCreateDto);
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
