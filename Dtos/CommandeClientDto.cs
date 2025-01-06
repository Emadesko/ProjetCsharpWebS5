using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Dtos
{
    public class CommandeClientDto{
        public PaginationModel<Commande> PaginationModel { get; set; }
        public Client Client { get; set; }
    }
}