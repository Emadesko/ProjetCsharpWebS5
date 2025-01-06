using ProjetCsharpWebS5.Enums;

namespace ProjetCsharpWebS5.Models
{
    public class Commande {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public float Montant { get; set; }
        public DateOnly Date { get; set; }
        public EtatCommande Etat { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
        public virtual Paiement? Paiement { get; set; }
        public virtual Livraison? Livraison { get; set; }
    }
}