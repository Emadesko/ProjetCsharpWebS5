using Microsoft.EntityFrameworkCore;
using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Data;
using ProjetCsharpWebS5.Dtos;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services.impl
{
    public class DetailService : IDetailService
    {

        private readonly ApplicationDbContext _context;

        public DetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Detail> Create(Detail Detail)
        {
            _context.Details.Add(Detail);
            await _context.SaveChangesAsync();
            return Detail;
        }

        public async Task<DetailCommandeDto> GetDetailsByCommandeByPaginate(int commandeId, int page, int pageSize)
        {
            var details = _context.Details.Where(c => c.CommandeId == commandeId).AsQueryable<Detail>();
            return new DetailCommandeDto{
                PaginationModel = await PaginationModel<Detail>.Paginate(details, pageSize, page),
                Commande = await _context.Commandes.SingleAsync<Commande>(c => c.Id == commandeId),
            };
            
        }

        public async Task<IEnumerable<Detail>> GetDatasAsync()
        {
            return await _context.Details.ToListAsync();
        }

        public async Task<PaginationModel<Detail>> GetDatasByPaginate(int page, int pageSize)
        {
            var Details = _context.Details.AsQueryable<Detail>();
            return await PaginationModel<Detail>.Paginate(Details, pageSize, page);
        }

        public async Task<Detail> GetById(int id)
        {
            return await _context.Details.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}