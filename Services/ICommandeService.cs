using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Dtos;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services
{
    public interface ICommandeService : IService<Commande>{
        Task<CommandeClientDto> GetCommandesByClientByPaginate(int clientId, int page, int pageSize);
    }
}