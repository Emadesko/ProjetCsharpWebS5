using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services
{
    public interface IClientService : IService<Client>{
        Task<Client> GetClientByLogin(string login);
    }
}