using Microsoft.AspNetCore.Mvc;
using ProjetCsharpWebS5.Models;
using ProjetCsharpWebS5.Services;
using System.Diagnostics;

namespace ProjetCsharpWebS5.Controllers
{
    public class ProduitController : Controller
    {
        private readonly ILogger<ProduitController> _logger;
        private readonly IProduitService _produitService;

        public ProduitController(ILogger<ProduitController> logger, IProduitService produitService)
        {
            _logger = logger;
            _produitService = produitService;
        }

        public async Task<IActionResult> Index(int page =1 , int pageSize =10)
        {
            var produits = await _produitService.GetDatasByPaginate(page,pageSize);
            return View(produits);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Libelle,Prix,QteStock,QteCeuil")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                var produitAdded = await _produitService.Create(produit);
                TempData["Message"] = "Produit créé avec succès!";
                return RedirectToAction(nameof(Index));
            }
            return View(produit);
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
