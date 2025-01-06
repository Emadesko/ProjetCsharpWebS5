using ProjetCsharpWebS5.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using ProjetCsharpWebS5.Data;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services.impl
{
    public class ProduitService : IProduitService
    {

        private readonly ApplicationDbContext _context;

        public ProduitService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Produit> Create(Produit produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
            return produit;
        }

        public async Task<IEnumerable<Produit>> GetDatasAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task<PaginationModel<Produit>> GetDatasByPaginate(int page, int pageSize)
        {
            var produits = _context.Produits.AsQueryable<Produit>();
            return await PaginationModel<Produit>.Paginate(produits, pageSize, page);
        }
        public async Task<Produit> GetById(int id)
        {
            return await _context.Produits.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}