using Microsoft.EntityFrameworkCore;
using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Data;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services.impl
{
    public class ClientService : IClientService
    {

        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> Create(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<IEnumerable<Client>> GetDatasAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<PaginationModel<Client>> GetDatasByPaginate(int page, int pageSize)
        {
            var clients = _context.Clients.AsQueryable<Client>();
            return await PaginationModel<Client>.Paginate(clients, pageSize, page);
        }

        public async Task<Client> GetById(int id)
        {
            return await _context.Clients.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Client> GetClientByLogin(string login)
        {
            return await _context.Clients.SingleOrDefaultAsync(c => c.User.Login == login);
        }
    }
}