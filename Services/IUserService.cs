using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services
{
    public interface IUserService : IService<User>{
        Task<User> GetUserByLogin(string login);
    }
}