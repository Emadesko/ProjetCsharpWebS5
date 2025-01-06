using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Dtos
{
    public class DetailCommandeDto{
        public PaginationModel<Detail> PaginationModel { get; set; }
        public Commande Commande { get; set; }
    }
}