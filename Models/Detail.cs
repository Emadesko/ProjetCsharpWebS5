using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetCsharpWebS5.Models
{
    public class Detail {
        public int Id { get; set; }
        public float Prix { get; set; }
        public int Qte { get; set; }
        [NotMapped]
        public float Total => Qte * Prix ; 
        public int ProduitId { get; set; }
        public virtual Produit Produit { get; set; }
        public int CommandeId { get; set; }
        public virtual Commande Commande { get; set; }
        
    }
}