using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services
{
    public interface IService <T>{
        Task<IEnumerable<T>> GetDatasAsync();
        Task<T> Create(T data);
        Task<PaginationModel<T>> GetDatasByPaginate(int page, int pageSize);
        Task<T> GetById(int id);
    }
}