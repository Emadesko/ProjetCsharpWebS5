using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Dtos;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Services
{
    public interface IDetailService : IService<Detail>{
        Task<DetailCommandeDto> GetDetailsByCommandeByPaginate(int commandeId, int page, int pageSize);
    }
}