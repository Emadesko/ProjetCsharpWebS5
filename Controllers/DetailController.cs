using Microsoft.AspNetCore.Mvc;
using ProjetCsharpWebS5.Dtos;
using ProjetCsharpWebS5.Models;
using ProjetCsharpWebS5.Services;
using System.Diagnostics;

namespace ProjetCsharpWebS5.Controllers
{
    public class DetailController : Controller
    {
        private readonly ILogger<DetailController> _logger;
        private readonly IDetailService _detailService;

        public DetailController(ILogger<DetailController> logger, IDetailService detailService)
        {
            _logger = logger;
            _detailService = detailService;
        }

        public async Task<IActionResult> Index(int page =1, int pageSize= 10)
        {
            var details = await _detailService.GetDatasByPaginate(page, pageSize);
            return View(details);
        }
        public async Task<IActionResult> DetailCommande(int commandeId, int page =1, int pageSize= 2)
        {
            var details = await _detailService.GetDetailsByCommandeByPaginate(commandeId, page, pageSize);
            return View(details);
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
