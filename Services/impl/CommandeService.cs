using Microsoft.EntityFrameworkCore;
using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Data;
using ProjetCsharpWebS5.Dtos;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services.impl
{
    public class CommandeService : ICommandeService
    {

        private readonly ApplicationDbContext _context;

        public CommandeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Commande> Create(Commande commande)
        {
            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();
            return commande;
        }

        public async Task<Commande> GetById(int id)
        {
            return await _context.Commandes.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CommandeClientDto> GetCommandesByClientByPaginate(int clientId, int page, int pageSize)
        {
            var commandes = _context.Commandes.Where(c => c.ClientId == clientId).AsQueryable<Commande>();
            return new CommandeClientDto{
                PaginationModel = await PaginationModel<Commande>.Paginate(commandes, pageSize, page),
                Client = await _context.Clients.SingleAsync<Client>(c => c.Id == clientId),
            };
            
        }

        public async Task<IEnumerable<Commande>> GetDatasAsync()
        {
            return await _context.Commandes.ToListAsync();
        }

        public async Task<PaginationModel<Commande>> GetDatasByPaginate(int page, int pageSize)
        {
            var commandes = _context.Commandes.AsQueryable<Commande>();
            return await PaginationModel<Commande>.Paginate(commandes, pageSize, page);
        }
    }
}