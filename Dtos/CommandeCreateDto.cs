using ProjetCsharpWebS5.Core.Pagination;
using ProjetCsharpWebS5.Models;

namespace ProjetCsharpWebS5.Dtos
{
    public class CommandeCreateDto
    {
        public PaginationModel<Produit> Produits { get; set; }
        public List<Detail> Details { get; set; } = new List<Detail>();
        public float TotalCommande { get; set; }
        public Client Client { get; set; }
    }

}